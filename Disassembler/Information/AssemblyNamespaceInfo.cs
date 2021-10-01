using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disassembly.Information
{
    public class AssemblyNamespaceInfo
    {
        internal List<AssemblyTypeInfo> _types = new List<AssemblyTypeInfo>();

        public string Name { get; }

        public AssemblyNamespaceInfo(string name)
        {
            Name = name;
        }

        public AssemblyTypeInfo[] GetTypes()
        {
            return _types.ToArray();
        }
    }
}
