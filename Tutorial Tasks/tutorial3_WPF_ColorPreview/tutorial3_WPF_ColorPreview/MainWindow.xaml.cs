using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

namespace tutorial3_WPF_ColorPreview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    class ColorToBrushConverter : IValueConverter
    {
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Color))
                return null;

            return new SolidColorBrush((Color)value);
        }
    }
    class ColorInfo
    {
        public string Name { get; set; }
        public string RGBinfo { get; set; }
        public Color RGB { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var props = typeof(Colors).GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            var colorInfos = props.Select(prop =>
            {
                var color = (Color)prop.GetValue(null, null);
                return new ColorInfo()
                {
                    Name = prop.Name,
                    RGB = color,
                    RGBinfo = $"R:{color.R} G:{color.G} B:{color.B}"
                };
            });
            this.DataContext = colorInfos;
        }
    }
}
