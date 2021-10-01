using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.Model
{
    public class AssemblyMembers
    {
        public List<AssemblyMember> Members { get; }
        public string Tag { get; }

        public AssemblyMembers(string tag, IEnumerable<AssemblyMember> collection)
        {
            Members = new List<AssemblyMember>(collection);
            Tag = tag;
        }
    }
}
