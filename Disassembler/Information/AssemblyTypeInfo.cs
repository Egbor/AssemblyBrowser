using System;
using System.Linq;
using System.Reflection;

namespace Disassembly.Information
{
    public class AssemblyTypeInfo
    {
        public string TypeName { get; }
        public string[] Fields { get; }
        public string[] Properties { get; }
        public string[] Methods { get; }

        public AssemblyTypeInfo(Type type)
        {
            MethodInfo[] accessors = Array.ConvertAll(type.GetProperties(), x => x.GetAccessors()).SelectMany(x => x).ToArray();
            MethodInfo[] onlyMethods = (from m in type.GetMethods() where !type.GetProperties().Any(p => p.GetGetMethod() == m || p.GetSetMethod() == m) select m).ToArray();

            TypeName = type.Name;
            Fields = Array.ConvertAll(type.GetFields(), x => x.ToString());
            Properties = Array.ConvertAll(accessors, x => x.ToString());
            Methods = Array.ConvertAll(onlyMethods, x => x.ToString());
        }
    }
}
