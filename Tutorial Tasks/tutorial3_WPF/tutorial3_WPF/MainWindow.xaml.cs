using System;
using System.Collections.Generic;
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

namespace tutorial3_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void resultButton_Click(object sender, RoutedEventArgs e)
        {
            double first, second;
            if (!double.TryParse(firstTextBox.Text, out first) || !double.TryParse(secondTextBox.Text, out second))
            {
                MessageBox.Show("Incorrect datainput");
                return;
            }

            switch (operationComboBox.Text)
            {
                case "+":
                    resultBox.Text = String.Format("{0}", first + second);
                    break;
                case "-":
                    resultBox.Text = String.Format("{0}", first - second);
                    break;
                case "*":
                    resultBox.Text = String.Format("{0}", first * second);
                    break;
                case "/":
                    if (second == 0)
                    {
                        MessageBox.Show("Second value is zero");
                        return;
                    }
                    resultBox.Text = String.Format("{0}", first / second);
                    break;
            }
        }
    }
}
