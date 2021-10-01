using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Disassembly.Information;

namespace AssemblyBrowser.Model
{
    public class AssemblyType : INotifyPropertyChanged
    {
        private string _typeName;

        public ObservableCollection<AssemblyMembers> Members { get; }

        public AssemblyMembers Fields { get; }
        public AssemblyMembers Properties { get; }
        public AssemblyMembers Methods { get; }

        public string TypeName
        {
            get { return _typeName; }
            set
            {
                _typeName = value;
                OnPropertyChanged("TypeName");
            }
        }

        public AssemblyType() { 
        
        }

        public AssemblyType(AssemblyTypeInfo info)
        {
            _typeName = info.TypeName;
            Fields = new AssemblyMembers("Fields", Array.ConvertAll(info.Fields, x => new AssemblyMember(x)));
            Properties = new AssemblyMembers("Properties", Array.ConvertAll(info.Properties, x => new AssemblyMember(x)));
            Methods = new AssemblyMembers("Methods", Array.ConvertAll(info.Methods, x => new AssemblyMember(x)));

            Members = new ObservableCollection<AssemblyMembers>();
            Members.Add(Fields);
            Members.Add(Properties);
            Members.Add(Methods);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
