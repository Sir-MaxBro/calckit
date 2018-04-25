using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculators.Domain.Abstract;
using Calculators.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using Calculators.Domain.Attributes;
using Calculators.Domain.Entities.Enums;

namespace Calculators.Domain.Calculators
{
    [Calculator("Математические калькуляторы", "Поиск НОД", "GreatestCommonDivisor")]
    public class GreatestCommonDivisor : Calculator
    {
        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Первое число")]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше 1")]      
        public int NumberA { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Второе число")]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше 1")] 
        public int NumberB { get; set; }

        public override CalculateResult Calculate()
        {
            int result = GreatestCommonDivisorFind(NumberA, NumberB);

            return new CalculateResult { Result = "НОД двух чисел равен: " + result, ResultType = ResultType.Article };
        }

        private static int GreatestCommonDivisorFind(int a, int b)
        {
            if (b == 0)
                return Math.Abs(a);
            return GreatestCommonDivisorFind(b, a % b);
        }
    }
}
