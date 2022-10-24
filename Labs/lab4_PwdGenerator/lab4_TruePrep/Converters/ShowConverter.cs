using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using lab4_TruePrep.TreeItems;
using lab4_TruePrep;

namespace lab4_TruePrep.Converters
{
    class ShowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;

            if (value is DirTreeItem)
                return new Uri("Dir.xaml", UriKind.Relative);

            if (value is ImgTreeItem)
                return new Uri("Img.xaml", UriKind.Relative);

            if (value is PswdTreeItem)
                return new Uri("Main.xaml", UriKind.Relative);

            throw new Exception("Failed to change page");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
