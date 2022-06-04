using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    class Spy
    {
        public string StealFieldInfo(string className, params string[] requiredFields)
        {
            var classType = Type.GetType(className);
            var fields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();
            var classInstance = Activator.CreateInstance(classType);
            sb.AppendLine($"Class under investigation: {className}");

            foreach (var field in fields.Where(x => requiredFields.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            var classType = Type.GetType(className);
            var fields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            var methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (var field in fields)
            {
                if (field.IsPublic)
                {
                    sb.AppendLine($"{field.Name} must be private!");
                }
            }

            foreach (var method in methods.Where(x => x.IsPrivate && x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in methods.Where(x => x.IsPublic && x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            var classType = Type.GetType(className);
            var privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {classType.FullName}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            var classType = Type.GetType(className);
            var methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic)
                .Where(x => x.Name.StartsWith("get") || x.Name.StartsWith("set"));
            StringBuilder sb = new StringBuilder();

            foreach (var method in methods)
            {
                if(method.Name.StartsWith("get"))
                {
                    sb.AppendLine($"{method.Name} will return {method.ReturnType.FullName}");
                }
                else
                {
                    sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
