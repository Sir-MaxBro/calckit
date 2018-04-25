using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculators.Domain.Abstract;
using Calculators.Domain.Entities.Enums;
using Calculators.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Calculators.Domain.Attributes;

namespace Calculators.Domain.Calculators
{
    [Calculator("Калькуляторы тела", "Калькулятор процента подкожного жира", "FatProcent")]
    public class FatProcent : Calculator
    {
        public FatProcent()
        {
            Waist = 80;
            Neck = 38;
            Height = 170;
            Thighs = 70;
        }

        [UIHint("Enum")]
        [Required(ErrorMessage = "Выберите значение")]
        [Display(Name = "Пол")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Талия, см")]
        [Range(10, 150, ErrorMessage="Значение должно быть в диапазоне от 10 до 150")]
        public double Waist { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Шея, см")]
        [Range(10, 50, ErrorMessage = "Значение должно быть в диапазоне от 10 до 50")]
        public double Neck { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Рост, см")]
        [Range(50, 250, ErrorMessage = "Значение должно быть в диапазоне от 50 до 250")]       
        public double Height { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Бедра, см")]
        [Range(10, 150, ErrorMessage = "Значение должно быть в диапазоне от 10 до 150")]     
        public double Thighs { get; set; }

        public override CalculateResult Calculate()
        {
            double result = 0;
            string errorMessage = "Неверно введены данные.";
            var calcResult = new CalculateResult { ResultType = ResultType.Article };
            switch (Gender)
            {
                case Gender.Man:
                    result = 495 / (1.0324 - 0.19077 * (Math.Log(Waist - Neck, 10)) + 0.15456 * (Math.Log(Height, 10))) - 450;
                    break;
                case Gender.Woman:
                    result = 495 / (1.29579 - 0.35004 * (Math.Log(Waist + Thighs - Neck, 10)) + 0.22100 * (Math.Log(Height, 10))) - 450;
                    break;
            }

            if (!CheckNotNegative(result))
            {
                calcResult.Result = errorMessage;
            }
            else
            {
                calcResult.Result = result.ToString("f2") + "%";
            }

            return calcResult;
        }
    }
}
