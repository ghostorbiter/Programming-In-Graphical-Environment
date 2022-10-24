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

using System.IO;
using System.Xml.Serialization;

namespace Lab3_Company
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private List<Company> _companyList = new List<Company>();
        public List<Company> CompanyList { get { return _companyList; } }

        private Company[] Deserelize(string filename)
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "ArrayOfCompany";
            root.Namespace = "";
            root.IsNullable = false;

            XmlSerializer mySerializer = new XmlSerializer(typeof(Company[]), root);


            Company[] returning;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                returning = (Company[])mySerializer.Deserialize(fs);
            }

            return returning;
        }
        public MainWindow()
        {
            InitializeComponent();

            _companyList = Deserelize("Companies.xml").ToList<Company>();

        }

        void Window_Loaded(object c, RoutedEventArgs e)
        {
            DataContext = CompanyList;
        }
    }
}
