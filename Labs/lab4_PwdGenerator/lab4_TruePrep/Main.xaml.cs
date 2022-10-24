using System;
using System.Collections.Generic;
using System.IO;
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
using lab4_TruePrep.Converters;

namespace lab4_TruePrep
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    /// 
    public class DummyTreeViewItem : TreeViewItem
    {
        public DummyTreeViewItem() : base()
        {
            base.Header = "DummyTreeViewItem";
            base.Tag = "DummyTreeViewItem";
        }
    }
    public partial class Main : Page
    {

        public Main()
        {
            InitializeComponent();
            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
                folderItem.Items.Add(GetItem(drive));
        }
        private TreeViewItem GetItem(DirectoryInfo directory)
        {
            var item = new TreeViewItem
            {
                Header = directory.Name,
                DataContext = directory,
                Tag = directory
            };
            this.AddDummy(item);
            item.Expanded += new RoutedEventHandler(item_Expanded);
            return item;
        }
        private TreeViewItem GetItem(FileInfo file)
        {
            var item = new TreeViewItem
            {
                Header = file.Name,
                DataContext = file,
                Tag = file
            };
            return item;
        }
        private TreeViewItem GetItem(DriveInfo drive)
        {
            var item = new TreeViewItem
            {
                Header = drive.Name,
                DataContext = drive,
                Tag = drive
            };
            this.AddDummy(item);
            item.Expanded += new RoutedEventHandler(item_Expanded);
            return item;
        }
        private void AddDummy(TreeViewItem item)
        {
            item.Items.Add(new DummyTreeViewItem());
        }

        private bool HasDummy(TreeViewItem item)
        {
            return item.HasItems && (item.Items.OfType<TreeViewItem>().ToList().FindAll(tvi => tvi is DummyTreeViewItem).Count > 0);
        }

        private void RemoveDummy(TreeViewItem item)
        {
            var dummies = item.Items.OfType<TreeViewItem>().ToList().FindAll(tvi => tvi is DummyTreeViewItem);
            foreach (var dummy in dummies)
            {
                item.Items.Remove(dummy);
            }
        }
        void item_Expanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;
            if (this.HasDummy(item))
            {
                this.Cursor = Cursors.Wait;
                this.RemoveDummy(item);
                this.ExploreDirectories(item);
                this.ExploreFiles(item);
                this.Cursor = Cursors.Arrow;
            }
        }
        private void ExploreDirectories(TreeViewItem item)
        {
            var directoryInfo = (DirectoryInfo)null;
            if (item.Tag is DriveInfo)
            {
                directoryInfo = ((DriveInfo)item.Tag).RootDirectory;
            }
            else if (item.Tag is DirectoryInfo)
            {
                directoryInfo = (DirectoryInfo)item.Tag;
            }
            else if (item.Tag is FileInfo)
            {
                directoryInfo = ((FileInfo)item.Tag).Directory;
            }
            if (object.ReferenceEquals(directoryInfo, null)) return;
            foreach (var directory in directoryInfo.GetDirectories())
            {
                var isHidden = (directory.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
                var isSystem = (directory.Attributes & FileAttributes.System) == FileAttributes.System;
                if (!isHidden && !isSystem)
                {
                    item.Items.Add(this.GetItem(directory));
                }
            }
        }
        private void ExploreFiles(TreeViewItem item)
        {
            var directoryInfo = (DirectoryInfo)null;
            if (item.Tag is DriveInfo)
            {
                directoryInfo = ((DriveInfo)item.Tag).RootDirectory;
            }
            else if (item.Tag is DirectoryInfo)
            {
                directoryInfo = (DirectoryInfo)item.Tag;
            }
            else if (item.Tag is FileInfo)
            {
                directoryInfo = ((FileInfo)item.Tag).Directory;
            }
            if (object.ReferenceEquals(directoryInfo, null)) return;
            foreach (var file in directoryInfo.GetFiles())
            {
                var isHidden = (file.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
                var isSystem = (file.Attributes & FileAttributes.System) == FileAttributes.System;
                if (!isHidden && !isSystem)
                {
                    item.Items.Add(this.GetItem(file));
                }
            }
        }
        private void logoutClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Login.xaml", UriKind.Relative));
        }

        private void selectedChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            List<string> ImageExtensions = new List<string> { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG" };
            var item = e.NewValue as TreeViewItem;
            if (item.Tag is FileInfo)
            {
                DataContext = item.Tag;
                var item2 = (FileInfo)item.Tag;
                string ext = item2.Extension.ToUpper();
                foreach (string s in ImageExtensions)
                {
                    if (ext == s)
                    {
                        NavigationService.Navigate(new Uri("Img.xaml", UriKind.Relative));
                    }
                }
            }
            else if (folderItem.SelectedItem is DirectoryInfo)
            {
                folderItem.ContextMenu = folderItem.Resources["DirectoryContextMenu"] as ContextMenu;
            }
            else
            {
                folderItem.ContextMenu = folderItem.Resources["DefaultContextMenu"] as ContextMenu;
            }

            //if (folderItem.SelectedItem is PswdTreeItem)
            //{
            //    folderItem.ContextMenu = folderItem.Resources["PwdContextMenu"] as ContextMenu;
            //}
            //else if (folderItem.SelectedItem is DirTreeItem)
            //{
            //    folderItem.ContextMenu = folderItem.Resources["DirContextMenu"] as ContextMenu;
            //}
            //else if (folderItem.SelectedItem is ImgTreeItem)
            //{
            //    folderItem.ContextMenu = folderItem.Resources["ImgContextMenu"] as ContextMenu;
            //}
            //else
            //{

            //}

        }

        private void mouseRightDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);

            if (treeViewItem != null)
            {
                treeViewItem.IsSelected = true;
                treeViewItem.Focus();
                e.Handled = true;
            }
            else
            {
                folderItem.ContextMenu = folderItem.Resources["DefaultContextMenu"] as System.Windows.Controls.ContextMenu;
            }
        }

        private TreeViewItem VisualUpwardSearch(DependencyObject dependencyObject)
        {
            while (dependencyObject != null && !(dependencyObject is TreeViewItem))
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            return dependencyObject as TreeViewItem;
        }

        private void renameClick(object sender, RoutedEventArgs e)
        {

        }
        private void delteClick(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
