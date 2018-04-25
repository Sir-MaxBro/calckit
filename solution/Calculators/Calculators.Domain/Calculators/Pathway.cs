using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculators.Domain.Abstract;
using Calculators.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using Calculators.Domain.Entities.Enums;
using Calculators.Domain.Attributes;

namespace Calculators.Domain.Calculators
{
    [Calculator("Дорожные калькуляторы", "Калькулятор топлива", "Pathway")]
    public class Pathway : Calculator
    {
        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Расход топлива, литр/км")]
        [Range(1, double.MaxValue, ErrorMessage = "Значение должно быть больше 1")]
        public double FuelConsumption { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Километров")]
        [Range(1, double.MaxValue, ErrorMessage = "Значение должно быть больше 1")]
        public double Kilometers { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Цена за литр топлива")]
        [Range(1, double.MaxValue, ErrorMessage = "Значение должно быть больше 1")]
        public double KilometerPrice { get; set; }

        public override CalculateResult Calculate()
        {
            double litrCount = FuelConsumption * Kilometers / 100;

            double resultPrice = litrCount * KilometerPrice;

            IDictionary<object, object> resultTable = new Dictionary<object, object>();

            resultTable.Add("Количество требуемых литров", "Цена");
            resultTable.Add(litrCount.ToString("f2"), resultPrice.ToString("f2"));

            return new CalculateResult { Result = resultTable, ResultType = ResultType.Table };
        }
    }
}
