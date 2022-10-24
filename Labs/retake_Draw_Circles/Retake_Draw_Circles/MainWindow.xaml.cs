using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Retake_Draw_Circles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DispatcherTimer Timer;
        private bool paused = true;
        private bool finished = false;
        public List<CircleClass> circles;
        private Random rand;

        public MainWindow()
        {
            InitializeComponent();
            circles = new List<CircleClass>();
            rand = new Random();

            Timer = new DispatcherTimer();
            Timer.Tick += TimerOnTick;
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            Timer.Start();

            for (int i = 0; i < 6; i++)
            {
                int radius = rand.Next(1, 50);
                int posX = rand.Next(1, 950);
                int poxY = rand.Next(1, 540);
                int thickness = rand.Next(1, 5);

                circles.Add(new CircleClass(radius, posX, poxY, thickness));
            }

            circlesGrid.ItemsSource = circles;
        }

        private void drawCircles()
        {
            foreach(CircleClass circle in circles)
            {
                Ellipse ellipse = new Ellipse
                {
                    Width = 2 * circle.radius,
                    Height = 2 * circle.radius,
                    Stroke = Brushes.Black,
                    StrokeThickness = circle.thickness
                };

                circlesHere.Children.Add(ellipse);
                ellipse.SetValue(Canvas.LeftProperty, (double)circle.posX);
                ellipse.SetValue(Canvas.TopProperty, (double)circle.posY);
            }
        }

        private void exitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void openClick(object sender, RoutedEventArgs e)
        {

        }
        private void newClick(object sender, RoutedEventArgs e)
        {

        }
        private void saveClick(object sender, RoutedEventArgs e)
        {

        }
        private void startClick(object sender, RoutedEventArgs e)
        {
            paused = false;
        }
        private void pauseClick(object sender, RoutedEventArgs e)
        {
            paused = true;
        }
        private void resetClick(object sender, RoutedEventArgs e)
        {
            progressBar.Value = 0;
            paused = true;
            finished = false;

            circlesHere.Children.Clear();
        }

        private void TimerOnTick(object sender, object o)
        {
            if (!paused)
            {
                progressBar.Value += 2;
            }

            if (progressBar.Value == progressBar.Maximum && !finished)
            {
                finished = true;
                drawCircles();
            }
        }
    }
}
