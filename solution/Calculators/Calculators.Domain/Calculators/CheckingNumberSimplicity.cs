using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Calculators.Domain.Abstract;
using Calculators.Domain.Attributes;
using Calculators.Domain.Entities;
using Calculators.Domain.Entities.Enums;

namespace Calculators.Domain.Calculators
{
    [Calculator("Математические калькуляторы", "Проверка числа на простоту", "CheckingNumberSimplicity")]
    public class CheckingNumberSimplicity : Calculator
    {
        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Число")]
        [Range(2, int.MaxValue, ErrorMessage = "Число должно быть не меньше 2")]
        public int Number { get; set; }

        public override CalculateResult Calculate()
        {
            var calcResult = new CalculateResult { Result = "Число простое", ResultType = ResultType.Article };
            for (int i = 2; i <= Math.Sqrt(Number); i++)
            {
                if (Number % i == 0)
                {
                    calcResult.Result = "Число не является простым";
                    break;
                }
            }
            return calcResult;
        }
    }
}
