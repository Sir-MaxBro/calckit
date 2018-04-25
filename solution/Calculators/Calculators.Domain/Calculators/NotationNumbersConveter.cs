using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculators.Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using Calculators.Domain.Entities.Enums;
using Calculators.Domain.Attributes;
using Calculators.Domain.Entities;
using Calculators.Domain.Helpers;

namespace Calculators.Domain.Calculators
{
    [Calculator("Конвертеры", "Конвертер систем счисления", "NotationNumbersConveter")]
    public class NotationNumbersConveter : Calculator
    {
        [UIHint("Enum")]
        [Required(ErrorMessage = "Выберите значение")]
        [Display(Name = "Система счисления")]
        public NumberSystems Notation { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Число")]
        public string Number { get; set; }

        public override CalculateResult Calculate()
        {
            IDictionary<object, object> resultRanges = new Dictionary<object, object>(); 

            var values = Enum.GetValues(typeof(global::Calculators.Domain.Entities.Enums.NumberSystems));

            var number = Convert.ToInt32(Number, (int)Notation);

            resultRanges.Add("Система счисления", "Значение");

            foreach (NumberSystems item in values)
            {
                int itemValue = (int)item;

                var attribute = item.GetAttributeOfType<DisplayAttribute>();
                string displayName = attribute.Name;

                resultRanges.Add(displayName, Convert.ToString(number, itemValue));
            }

            return new CalculateResult { Result = resultRanges, ResultType = ResultType.Table };
        }
    }
}
