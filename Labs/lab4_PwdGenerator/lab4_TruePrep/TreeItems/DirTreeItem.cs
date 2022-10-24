using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace lab4_TruePrep.TreeItems
{
    [Serializable]
    class DirTreeItem : IBase
    {
        public static int Count { get; set; }
        private string _header;
        private bool _isEdit = false;
        private ObservableCollection<IBase> _items;
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
        public ObservableCollection<IBase> Items
        {
            get
            {
                if (_items is null)
                {
                    _items = new ObservableCollection<IBase>();
                }
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("DirItems");
            }
        }
    }
}
