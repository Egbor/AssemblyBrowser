using System.ComponentModel;
using System.Collections.ObjectModel;
using Disassembly.Information;

namespace AssemblyBrowser.Model
{
    public class AssemblyNamespace : INotifyPropertyChanged
    {
        private string _name;

        public ObservableCollection<AssemblyType> Types { get; }

        public string Name
        {
            get { return _name; }
            set 
            {
                _name = value;
                OnPropertyChanged("Name"); 
            }
        }

        public AssemblyNamespace()
        {

        }

        public AssemblyNamespace(AssemblyNamespaceInfo info)
        {
            _name = info.Name;
            Types = new ObservableCollection<AssemblyType>();
            foreach (AssemblyTypeInfo typeInfo in info.GetTypes())
            {
                Types.Add(new AssemblyType(typeInfo));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
