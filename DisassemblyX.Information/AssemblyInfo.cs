using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Disassembly.Information
{
    public class AssemblyInfo : AssemblyInfoMember
    {
        public AssemblyInfo(Type[] types) : base("root")
        {
            foreach (Type type in types)
            {
                AssemblyInfoMember member = FindMember(type, _infos);//_infos.Find(x => (x.Content == type.Namespace) || ((type.Namespace == null) && (x.Content == "Unknown")));
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
            }
        }

        private static AssemblyInfoMember FindMember(Type type, ObservableCollection<AssemblyInfoMember> infos)
        {
            foreach (AssemblyInfoMember member in infos)
            {
                if (member.Content == type.Namespace)
                {
                    return member;
                }
            }
            return null;
        }

        private static void AddRangeMembers(IEnumerable<AssemblyInfoMember> members, ObservableCollection<AssemblyInfoMember> infos)
        {
            foreach (AssemblyInfoMember member in members)
            {
                infos.Add(member);
            }
        }

        private void ScannFields(AssemblyInfoMember member, Type type)
        {
            if (type.GetFields().Length > 0)
            {
                AssemblyInfoMember fields = new AssemblyInfoMember("Fields");
                AddRangeMembers(Array.ConvertAll(type.GetFields(), x => new AssemblyInfoMember(x.ToString())), fields._infos);
                member._infos.Add(fields);
            }
        }

        private void ScannProperites(AssemblyInfoMember member, Type type)
        {
            if (type.GetProperties().Length > 0)
            {
                MethodInfo[] accessors = Array.ConvertAll(type.GetProperties(), x => x.GetAccessors()).SelectMany(x => x).ToArray();

                AssemblyInfoMember properties = new AssemblyInfoMember("Properties");
                AddRangeMembers(Array.ConvertAll(accessors, x => new AssemblyInfoMember(x.ToString())), properties._infos);
                member._infos.Add(properties);
            }
        }

        private void ScannMethods(AssemblyInfoMember member, Type type)
        {
            if (type.GetMethods().Length > 0)
            {
                MethodInfo[] onlyMethods = (from m in type.GetMethods() where !type.GetProperties().Any(p => p.GetGetMethod() == m || p.GetSetMethod() == m) select m).ToArray();

                AssemblyInfoMember methods = new AssemblyInfoMember("Methods");
                AddRangeMembers(Array.ConvertAll(onlyMethods, x => new AssemblyInfoMember(x.ToString())), methods._infos);
                member._infos.Add(methods);
            }
        }
    }
}
