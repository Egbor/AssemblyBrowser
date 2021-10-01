using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disassembly.Information
{
    public class AssemblyInfoMember
    {
        internal ObservableCollection<AssemblyInfoMember> _infos = new ObservableCollection<AssemblyInfoMember>();

        public string Content { get; }

        public AssemblyInfoMember(string content)
        {
            Content = content;
        }

        public AssemblyInfoMember[] Members => _infos.ToArray();

    }
}
