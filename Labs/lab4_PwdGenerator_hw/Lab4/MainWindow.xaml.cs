using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Windows.Forms;

namespace Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private List<RectangleClass> _rects;
        private List<string> _files;
        private List<ISlideShowEffect> _DLLeffects = new List<ISlideShowEffect>();
        public MainWindow()
        {
            InitializeComponent();
            _files = new List<string>();

            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
                this.folderItem.Items.Add(createItem(drive));

            var showEffectType = typeof(ISlideShowEffect);

            DirectoryInfo dir = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);
            foreach (FileInfo file in dir.GetFiles("*.dll"))
            {
                Assembly assembly = Assembly.LoadFrom(file.FullName);
                foreach (Type type in assembly.GetExportedTypes())
                {
                    if (showEffectType.IsAssignableFrom(type) && type.IsAbstract == false)
                    {
                        ISlideShowEffect b = type.InvokeMember(null,
                                      BindingFlags.CreateInstance,
                                      null, null, null) as ISlideShowEffect;

                        _DLLeffects.Add(b);
                    }
                }
            }

            foreach (var plugin in _DLLeffects)
            {
                System.Windows.Controls.MenuItem item = new System.Windows.Controls.MenuItem();
                item.Header = plugin.Name;
                item.Click += EffectClick;
                slideShowMenu.Items.Add(item);

                comboBox.Items.Add(plugin.Name);
            }

            comboBox.Text = _DLLeffects.Count == 0 ? "" : _DLLeffects[0].Name;
        }

       
        void item_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem treeItem = (TreeViewItem)e.Source;
            if ((treeItem.Items.Count == 1) && (treeItem.Items[0] is string))
            {
                treeItem.Items.Clear();
                DirectoryInfo dirInfo = null;
                if (treeItem.Tag is DriveInfo)
                    dirInfo = (treeItem.Tag as DriveInfo).RootDirectory;
                if (treeItem.Tag is DirectoryInfo)
                    dirInfo = (treeItem.Tag as DirectoryInfo);
                try
                {
                    foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
                        treeItem.Items.Add(createItem(subDir));
                }
                catch { }
            }
        }

        private TreeViewItem createItem(object sender)
        {
            TreeViewItem treeItem = new TreeViewItem();
            treeItem.Header = sender.ToString();
            treeItem.Tag = sender;
            treeItem.Items.Add("");
            return treeItem;
        }

        private void aboutClick(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This is about message box!", "About", MessageBoxButton.OK);
        }
        private void exitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void openFolderClick(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result.ToString() != string.Empty)
            {
                var list1 = Directory.GetFiles(dialog.SelectedPath, "*.png");
                var list2 = list1.Concat(Directory.GetFiles(dialog.SelectedPath, "*.jpg"));
                var list3 = list2.Concat(Directory.GetFiles(dialog.SelectedPath, "*.jpeg"));
                var list4 = list3.Concat(Directory.GetFiles(dialog.SelectedPath, "*.bmp"));
                var list5 = list4.Concat(Directory.GetFiles(dialog.SelectedPath, "*.gif"));
                var finalList = list5.ToList();

                List<RectangleClass> rectangles = MakeRectangles(finalList);
                pictureItem.ItemsSource = _rects = rectangles;

                foreach (var rect in _rects)
                    _files.Add(rect.Image);
            }
        }

        private void selectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (((TreeViewItem)folderItem.SelectedItem).Tag is DirectoryInfo dirInfo)
            {
                if (dirInfo.ToString() != string.Empty)
                {
                    var finalList = dirInfo.GetFiles().Where(f => (f.FullName.EndsWith(".jpg") || f.Name.EndsWith(".jpeg") || f.Name.EndsWith(".png") ||
                                                        f.Name.EndsWith(".bmp") || f.Name.EndsWith(".gif"))).ToList();
                    List<string> finalString = new List<string>();

                    foreach(var list in finalList)
                    {
                        finalString.Add(list.FullName);
                    }

                    List<RectangleClass> rectangles = MakeRectangles(finalString);
                    pictureItem.ItemsSource = _rects = rectangles;

                    foreach (var rect in _rects)
                        _files.Add(rect.Image);
                }
            }
        }

        private List<RectangleClass> MakeRectangles(List<string> list)
        {
            List<RectangleClass> rectangles = new List<RectangleClass>();

            foreach (var path in list)
            {
                BitmapFrame bit = BitmapFrame.Create(new Uri(path), BitmapCreateOptions.DelayCreation, BitmapCacheOption.None);

                rectangles.Add(new RectangleClass()
                {
                    Name = System.IO.Path.GetFileName(path),
                    Size = new FileInfo(path).Length / 1024f,
                    Width = bit.PixelWidth,
                    Height = bit.PixelHeight,
                    Image = System.IO.Path.GetFullPath(path)
                });
            }

            return rectangles;
        }

        private void startSlideShow(object sender, RoutedEventArgs e)
        {
            if (_rects is null || _rects.Count == 0)
            {
                System.Windows.MessageBox.Show("The selected folder does not contain any image to start slideshow", "An error occured", MessageBoxButton.OK);
                return;
            }

            string ans = comboBox.Text;
            var obj = _DLLeffects.Find(f => f.Name == ans);

            slideShowWindow newSlideWindow = new slideShowWindow(_files, obj);
            newSlideWindow.ShowDialog();
            newSlideWindow.ShowInTaskbar = false;
        }

        private void EffectClick(object sender, RoutedEventArgs e)
        {
            if (_rects is null || _rects.Count == 0)
            {
                System.Windows.MessageBox.Show("The selected folder does not contain any image to start slideshow", "An error occured", MessageBoxButton.OK);
                return;
            }

            var obj = _DLLeffects.Find(f => f.Name == (string)(sender as System.Windows.Controls.MenuItem).Header);

            slideShowWindow newSlideWindow = new slideShowWindow(_files, obj);
            newSlideWindow.ShowDialog();
            newSlideWindow.ShowInTaskbar = false;
        }
    }
}
