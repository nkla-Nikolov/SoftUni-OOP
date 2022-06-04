using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var classType = Type.GetType("AuthorProblem.StartUp");
            var methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            foreach (var method in methods)
            {
                if(method.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(true);

                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }
        }
    }
}
