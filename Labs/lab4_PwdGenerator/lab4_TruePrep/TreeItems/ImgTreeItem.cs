using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace lab4_TruePrep.TreeItems
{
    [Serializable]
    class ImgTreeItem : IBase
    {
        public static int Count { get; set; }
        private string _header;
        private bool _isEdit = false;
        [field: NonSerializedAttribute()]
        private BitmapImage _image;
        public string Header
        {
            get => _header;

            set
            {
                _header = value;
                OnPropertyChanged("Header");
            }
        }
        public bool IsEditable
        {
            get => _isEdit;
            set
            {
                _isEdit = value;
                OnPropertyChanged("IsEditable");
            }
        }
        public BitmapImage Image
        {
            get => _image;
            set
            {
                _image = value;
            }
        }
    }
}
