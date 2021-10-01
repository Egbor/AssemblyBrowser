using System.Reflection;
using Disassembly.Information;

namespace Disassembly
{
    public class Disassembler
    {
        public AssemblyInfo Run(string path)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            return new AssemblyInfo(assembly.GetTypes());
        }
    }
}
