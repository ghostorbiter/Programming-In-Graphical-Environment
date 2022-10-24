using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab4
{
    /// <summary>
    /// Interaction logic for slideShowWindow.xaml
    /// </summary>
    public partial class slideShowWindow : Window, INotifyPropertyChanged
    {
        private List<string> _files;
        private ISlideShowEffect _effect;
        private int _counter;

        private bool _pause = false;
        private Timer _timer;

        public slideShowWindow()
        {
            InitializeComponent();
        }


        public slideShowWindow(List<string> files, ISlideShowEffect effect) : this()
        {
            _files = files;
            //imgSlide.Source = new BitmapImage(new Uri("h:\\Windows7\\Desktop\\yusupovy win\\Lab4\\Lab4\\bin\\Debug\\BLANK_ICON.png"));
            nextImgSlide.Source = new BitmapImage(new Uri(_files[_counter]));
            _effect = effect;
            DataContext = this;

            Loaded += Window_Loaded;
        }

        private void playPauseSlideShow(object sender, RoutedEventArgs e)
        {
            _pause = !_pause;
        }

        private void stopSlideShow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new Timer();
            _timer.Elapsed += timer_Tick;
            _timer.Interval = 4000;
            _counter = 0;

            _timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!_pause)
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    //BitmapImage bitmapImage = new BitmapImage(new Uri(_files[_counter]));
                    //imgSlide.Source = bitmapImage;
                    int oldCounter = _counter++ % _files.Count();

                    imgSlide.Source = new BitmapImage(new Uri(_files[oldCounter]));
                    nextImgSlide.Source = new BitmapImage(new Uri(_files[_counter % _files.Count()]));
                    _effect.Play(nextImgSlide, imgSlide, this.ActualWidth, this.ActualHeight);
                }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
