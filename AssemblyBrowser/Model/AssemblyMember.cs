using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser.Model
{
    public class AssemblyMember
    {
        public string Content { get;  }

        public AssemblyMember(string content)
        {
            Content = content;
        }
    }
}
