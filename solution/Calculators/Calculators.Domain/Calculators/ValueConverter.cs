using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculators.Domain.Abstract;
using Calculators.Domain.Entities.Enums;
using Calculators.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using Calculators.Domain.Attributes;
using Calculators.Domain.Helpers;

namespace Calculators.Domain.Calculators
{
    [Calculator("Конвертеры", "Конвертер объема", "ValueConverter")]
    public class ValueConverter : Calculator
    {
        private const int COEFF = 100000;

        [UIHint("Enum")]
        [Required(ErrorMessage = "Выберите значение")]
        [Display(Name = "Единицы объема")]
        public Value ValueType { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Значение")]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Значение должно быть больше 0,0001")]
        public double Value { get; set; }

        public override CalculateResult Calculate()
        {
            Dictionary<object, object> resultRanges = new Dictionary<object, object>();
            resultRanges.Add("Единицы измерения", "Значение");

            var values = Enum.GetValues(typeof(global::Calculators.Domain.Entities.Enums.Value));
            double currentValueType = (int)ValueType;
            currentValueType /= COEFF;
            foreach (Value item in values)
            {
                double itemValue = (int)item;
                itemValue /= COEFF;
                var attribute = item.GetAttributeOfType<DisplayAttribute>();
                string displayName = attribute.Name;
                double convertValue = this.Value * (itemValue / currentValueType);

                resultRanges.Add(displayName, convertValue.ToString("f7"));
            }

            return new CalculateResult { Result = resultRanges, ResultType = ResultType.Table };
        }
    }
}
