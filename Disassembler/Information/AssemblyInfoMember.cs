using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disassembly.Information
{
    public class AssemblyInfoMember
    {
        internal List<AssemblyInfoMember> _infos = new List<AssemblyInfoMember>();

        public string Content { get; }

        public AssemblyInfoMember(string content)
        {
            Content = content;
        }

        public AssemblyInfoMember[] GetMembers()
        {
            return _infos.ToArray();
        }
    }
}
