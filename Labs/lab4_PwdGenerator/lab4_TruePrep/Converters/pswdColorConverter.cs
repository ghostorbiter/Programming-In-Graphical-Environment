using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using lab4_TruePrep;

namespace lab4_TruePrep.Converters
{
    class pswdColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PasswordStrength result = PasswordStrengthUtils.CalculatePasswordStrength((string)value);
            SolidColorBrush brush = null;
            switch (result)
            {
                case PasswordStrength.Invalid:
                    brush = new SolidColorBrush(Colors.Red);
                    break;
                case PasswordStrength.VeryWeak:
                    brush = new SolidColorBrush(Colors.Orange);
                    break;
                case PasswordStrength.Weak:
                    brush = new SolidColorBrush(Colors.Yellow);
                    break;
                case PasswordStrength.Average:
                    brush = new SolidColorBrush(Colors.LightBlue);
                    break;
                case PasswordStrength.Strong:
                    brush = new SolidColorBrush(Colors.LightGreen);
                    break;
                case PasswordStrength.VeryStrong:
                    brush = new SolidColorBrush(Colors.Green);
                    break;
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
