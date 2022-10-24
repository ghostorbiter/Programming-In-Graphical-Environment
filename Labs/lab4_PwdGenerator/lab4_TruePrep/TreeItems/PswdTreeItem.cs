using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_TruePrep.TreeItems
{
    [Serializable]
    class PswdTreeItem : IBase
    {
        public static int Count { get; set; }
        private string _header;
        private bool _isEdit = false;
        private ObservableCollection<Pswd> _passwords;
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
        public ObservableCollection<Pswd> Passwords
        {
            get
            {
                if (_passwords is null)
                    _passwords = new ObservableCollection<Pswd>();
                return _passwords;
            }
            set
            {
                _passwords = value;
                OnPropertyChanged("Passwords");
            }
        }
    }
}
