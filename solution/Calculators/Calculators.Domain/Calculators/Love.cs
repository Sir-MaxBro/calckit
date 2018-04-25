using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculators.Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using Calculators.Domain.Attributes;
using Calculators.Domain.Entities;
using Calculators.Domain.Entities.Enums;

namespace Calculators.Domain.Calculators
{
    [Calculator("Разное", "Калькулятор любви", "Love")]
    public class Love : Calculator
    {
        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Первое имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Второе имя")]
        public string SecondName { get; set; }

        public override CalculateResult Calculate()
        {
            double compatibilityPercentage = 0;
            double firstNameCode = GetStringCode(FirstName.ToLower());
            double secondNameCode = GetStringCode(SecondName.ToLower());

            compatibilityPercentage = firstNameCode <= secondNameCode ? firstNameCode / secondNameCode : secondNameCode / firstNameCode;

            return new CalculateResult
            {
                Result = (compatibilityPercentage * 100).ToString("f2") + "%",
                ResultType = ResultType.Article
            };
        }

        private int GetStringCode(string value)
        {
            int stringCode = 0;
            foreach (var item in value)
            {
                unchecked
                {
                    stringCode += item;
                }
            }
            return stringCode;
        }
    }
}
