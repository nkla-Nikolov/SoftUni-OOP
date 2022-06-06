using System;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var attributes = prop
                    .GetCustomAttributes()
                    .Where(x => x.GetType()
                    .IsSubclassOf(typeof(MyValidationAttribute)))
                    .ToArray();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(prop.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
