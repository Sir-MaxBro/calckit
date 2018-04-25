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
    [Calculator("Калькуляторы тела", "Калькулятор индекса массы тела", "BodyMassIndex")]
    public class BodyMassIndex : Calculator
    {
        public BodyMassIndex()
        {
            Weight = 70;
            Height = 170;
        }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Вес, кг")]
        [Range(1, 200, ErrorMessage="Значение должно быть в диапазоне от 1 до 200")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Рост, см")]
        [Range(50, 250, ErrorMessage = "Значение должно быть в диапазоне от 50 до 250")]
        public double Height { get; set; }

        public override CalculateResult Calculate()
        {
            string errorMessage = "Неверно введены данные.";
            double result = Weight * 10000 / (Math.Pow(Height, 2));
            var calcResult = new CalculateResult { Result = result.ToString("f2"), ResultType = ResultType.Article };

            if (!CheckNotNegative(result))
            {
                calcResult.Result = errorMessage;
            }

            return calcResult;
        }
    }
}
