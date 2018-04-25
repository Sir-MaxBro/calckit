using Calculators.Domain.Abstract;
using Calculators.Domain.Entities;
using Calculators.Domain.Entities.Enums;
using Calculators.Domain.Attributes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace Calculators.Domain.Calculators
{
    [Calculator("Калькуляторы тела", "Калькулятор калорий", "Calories")]
    public class Calories : Calculator
    {
        public Calories()
        {
            Weight = 70;
            Height = 170;
            Age = 18;
        }

        [UIHint("Enum")]
        [Required(ErrorMessage = "Выберите значение")]
        [Display(Name = "Пол")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Вес, кг")]
        [Range(1, 200, ErrorMessage = "Значение должно быть в диапазоне от 1 до 200")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Рост, см")]
        [Range(50, 250, ErrorMessage = "Значение должно быть в диапазоне от 50 до 250")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Возраст, лет")]
        [Range(0.1, 110, ErrorMessage = "Значение должно быть от 0.1 до 110")]
        public double Age { get; set; }

        [UIHint("Enum")]
        [Required(ErrorMessage = "Выберите значение")]
        [Display(Name = "Уровень физической активности")]
        public Activity Activity { get; set; }

        public override CalculateResult Calculate()
        {
            string errorMessage = "Неверно введены данные";
            StringBuilder sb = new StringBuilder();
            var calcResult = new CalculateResult { ResultType = ResultType.Article };

            var resultDescription = new string[] {
                "Для снижение веса: ",
                "Для поддержания веса: ",
                "Для набора массы: "
            };
            double result = 0;
            switch (Gender)
            {
                case Gender.Man:
                    result = 88.36 + (13.4 * Weight) + (4.8 * Height) - (5.7 * Age);
                    break;
                case Gender.Woman:
                    result = 447.6 + (9.2 * Weight) + (3.1 * Height) - (4.3 * Age);
                    break;
            }

            if (!CheckNotNegative(result))
            {
                calcResult.Result = errorMessage;
            }
            else
            {
                result *= (int)Activity / 10.0;

                for (int i = 500; i >= -500; i -= 500)
                {
                    sb.AppendLine(resultDescription[Math.Abs(i - 500) / 500] + (result - i).ToString("f2") + " ккал");
                }

                calcResult.Result = sb.ToString();
            }
            return calcResult;
        }
    }
}
