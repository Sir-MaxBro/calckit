using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculators.Domain.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class CalculatorAttribute : Attribute
    {
        private string category;
        private string name;
        private string type;

        public CalculatorAttribute(string category, string name, string type)
        {
            this.category = category;
            this.name = name;
            this.type = type;
        }

        public string Category { get { return category; } }

        public string Name { get { return name; } }

        public string Type { get { return type; } }
    }
}
