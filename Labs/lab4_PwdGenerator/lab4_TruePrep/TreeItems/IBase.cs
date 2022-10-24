using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace lab4_TruePrep.TreeItems
{
    [Serializable]
    public abstract class IBase : INotifyPropertyChanged
    {
        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<IBase> _parent;
        public ObservableCollection<IBase> Parent
        {
            get => _parent;
            set
            {
                _parent = value;
                OnPropertyChanged("Parent");
            }
        }
        public IBase() { }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
