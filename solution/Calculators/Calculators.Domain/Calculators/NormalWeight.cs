using Calculators.Domain.Abstract;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Calculators.Domain.Entities.Enums;
using Calculators.Domain.Attributes;
using Calculators.Domain.Entities;

namespace Calculators.Domain.Calculators
{
    [Calculator("Калькуляторы тела", "Калькулятор нормального веса", "NormalWeight")]
    public class NormalWeight : Calculator
    {
        public NormalWeight()
        {
            Height = 170;
        }

        [UIHint("Enum")]
        [Required(ErrorMessage = "Выберите значение")]
        [Display(Name = "Пол")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Рост, см")]
        [Range(50, 250, ErrorMessage = "Значение должно быть в диапазоне от 50 до 250")]
        public double Height { get; set; }

        public override CalculateResult Calculate()
        {         
            double result = 0;
            string errorMessage = "Неверно введены данные.";
            var calcResult = new CalculateResult { ResultType = ResultType.Article };
            switch (Gender)
            {
                case Gender.Man:
                    result = (Height - 100) - ((Height - 100) - 52) * 1.0 / 5;
                    break;
                case Gender.Woman:
                    result = (Height - 100) - ((Height - 100) - 52) * 2.0 / 5;
                    break;
            }

            if (!CheckNotNegative(result))
            {
                calcResult.Result = errorMessage;
            }
            else
            {
                calcResult.Result = result.ToString("f0") + " кг";
            }

            return calcResult;
        }
    }
}
