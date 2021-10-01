using System.ComponentModel;
using AssemblyBrowser.Model;
using AssemblyBrowser.Command;
using Microsoft.Win32;

namespace AssemblyBrowser.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private AssemblyTree _tree;
        private RelayCommand _command;

        public AssemblyTree Tree 
        {
            get { return _tree; }
            set
            {
                _tree = value;
                OnPropertyChanged("Tree");
            }

        }
        public RelayCommand OpenFile
        {
            get { return _command; }
            set
            {
                _command = value;
                OnPropertyChanged("OpenFile");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ApplicationViewModel()
        {
            _tree = new AssemblyTree();
            _command = new RelayCommand(action => OpenLibrary());
        }

        private void OpenLibrary()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == true)
            {
                _tree.Create(openDialog.FileName);
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
