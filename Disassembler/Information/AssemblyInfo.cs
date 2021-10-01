using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Disassembly.Information
{
    public class AssemblyInfo : AssemblyInfoMember
    {
        //internal List<AssemblyNamespaceInfo> _namespaces = new List<AssemblyNamespaceInfo>();

        public AssemblyInfo(Type[] types) : base("root")
        {
            foreach (Type type in types)
            {
                AssemblyInfoMember member = _infos.Find(x => (x.Content == type.Namespace) || ((type.Namespace == null) && (x.Content == "Unknown")));
                AssemblyInfoMember newMember = new AssemblyInfoMember(type.Name);

                ScannFields(newMember, type);
                ScannProperites(newMember, type);
                ScannMethods(newMember, type);

                if (member == null)
                {
                    member = new AssemblyInfoMember(type.Namespace == null ? "Unknown" : type.Namespace);
                    _infos.Add(member);
                }

                member._infos.Add(newMember);

                //AssemblyNamespaceInfo namespaceInfo = _namespaces.Find(x => (x.Name == type.Namespace) || ((type.Namespace == null) && (x.Name == "Unknown")));
                //AssemblyTypeInfo typeInfo = new AssemblyTypeInfo(type);

                //if (namespaceInfo == null)
                //{
                //    namespaceInfo = new AssemblyNamespaceInfo(type.Namespace == null ? "Unknown" : type.Namespace);
                //    _namespaces.Add(namespaceInfo);
                //}

                //namespaceInfo._types.Add(typeInfo);
            }
        }

        private void ScannFields(AssemblyInfoMember member, Type type)
        {
            if (type.GetFields().Length > 0)
            {
                AssemblyInfoMember fields = new AssemblyInfoMember("Fields");
                fields._infos.AddRange(Array.ConvertAll(type.GetFields(), x => new AssemblyInfoMember(x.ToString())));
                member._infos.Add(fields);
            }
        }

        private void ScannProperites(AssemblyInfoMember member, Type type)
        {
            if (type.GetProperties().Length > 0)
            {
                MethodInfo[] accessors = Array.ConvertAll(type.GetProperties(), x => x.GetAccessors()).SelectMany(x => x).ToArray();

                AssemblyInfoMember properties = new AssemblyInfoMember("Properties");
                properties._infos.AddRange(Array.ConvertAll(accessors, x => new AssemblyInfoMember(x.ToString())));
                member._infos.Add(properties);
            }
        }

        private void ScannMethods(AssemblyInfoMember member, Type type)
        {
            if (type.GetMethods().Length > 0)
            {
                MethodInfo[] onlyMethods = (from m in type.GetMethods() where !type.GetProperties().Any(p => p.GetGetMethod() == m || p.GetSetMethod() == m) select m).ToArray();

                AssemblyInfoMember methods = new AssemblyInfoMember("Methods");
                methods._infos.AddRange(Array.ConvertAll(onlyMethods, x => new AssemblyInfoMember(x.ToString())));
                member._infos.Add(methods);
            }
        }

        //public AssemblyNamespaceInfo[] GetNamespaces()
        //{
        //    return _namespaces.ToArray();
        //}
    }
}
