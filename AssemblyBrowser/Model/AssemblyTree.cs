using System.ComponentModel;
using Disassembly;
using Disassembly.Information;

namespace AssemblyBrowser.Model
{
    public class AssemblyTree : INotifyPropertyChanged
    {
        private Disassembler _disassembler = new Disassembler();
        private AssemblyInfoMember _members = null;

        public AssemblyInfoMember Members 
        {
            get { return _members; }
            set 
            {
                _members = value;
                OnPropertyChanged("Members");
            }
        }

        public AssemblyTree()
        {
        }

        public void Create(string path)
        {
            Members = _disassembler.Run(path);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
