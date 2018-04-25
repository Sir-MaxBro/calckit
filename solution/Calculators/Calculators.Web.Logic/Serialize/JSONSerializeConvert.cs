using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Calculators.Web.Logic.Factory;

namespace Calculators.Web.Logic.Serialize
{
    internal class JSONSerializeConvert
    {
        public static object DeserializeCalculator(string jsonData)
        {
            // split json by &
            var data = jsonData.Split('&').ToList();
            string className = "";
            string calculatorPropertyName = "CalculatorName";
            var propertyValue = new object();
            // find class name of calculator
            Regex regex = new Regex(calculatorPropertyName);
            for (int i = data.Count - 1; i >= 0; i--)
            {
                if (regex.IsMatch(data[i]))
                {
                    className = data[i].Split('=').ElementAt(1);
                    break;
                }
            }
            // get calculator class instance
            var calculator = CalculatorFactory.GetCalculate(className);

            for (int i = 0; i < data.Count; i++)
            {
                // get property
                var property = data[i].Split('=');
                // get property name
                string propertyName = property.ElementAt(0);
                // doesn't set property "CalculatorName"
                if (propertyName == calculatorPropertyName)
                {
                    break;
                }
                // get calculator property
                var calculatorProperty = calculator.GetType()
                    .GetProperty(propertyName, System.Reflection.BindingFlags.Public
                    | System.Reflection.BindingFlags.Instance);

                var propertyType = calculatorProperty.PropertyType;
                if (propertyType.BaseType == typeof(Enum))
                {
                    // if property is Enum
                    propertyValue = Enum.Parse(propertyType, property.ElementAt(1));
                }
                else
                {
                    // change type of value
                    propertyValue = Convert.ChangeType(property.ElementAt(1), propertyType);
                }

                //set property
                calculatorProperty.SetValue(calculator, propertyValue);
            }
            return calculator;
        }
    }
}
