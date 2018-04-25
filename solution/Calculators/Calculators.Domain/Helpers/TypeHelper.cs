using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculators.Domain.Abstract;

namespace Calculators.Domain.Helpers
{
    public static class TypeHelper
    {
        public static T GetAttributeOfType<T>(this Type type)
            where T : Attribute
        {
            var attributes = type.GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }
}
