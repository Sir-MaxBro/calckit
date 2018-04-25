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
    [Calculator("Математические калькуляторы", "Поиск НОК", "LeastCommonMultiple")]
    public class LeastCommonMultiple : Calculator
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
            int result = NumberA * NumberB / GreatestCommonDivisorFind(NumberA, NumberB);

            return new CalculateResult { Result = "НОК двух чисел равен: " + result, ResultType = ResultType.Article };
        }

        private static int GreatestCommonDivisorFind(int a, int b)
        {
            if (b == 0)
                return Math.Abs(a);
            return GreatestCommonDivisorFind(b, a % b);
        }
    }
}
