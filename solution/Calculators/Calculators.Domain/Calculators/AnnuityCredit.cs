using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculators.Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Calculators.Domain.Attributes;
using Calculators.Domain.Entities;
using Calculators.Domain.Entities.Enums;

namespace Calculators.Domain.Calculators
{
    [Calculator("Кредитные калькуляторы", "Калькулятор аннуиентного кредита", "AnnuityCredit")]
    public class AnnuityCredit : Calculator
    {
        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Сумма кредита")]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Неверное введено значение")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Процент, %")]
        [Range(0.00001, 100, ErrorMessage = "Значение должно быть в диапазоне от 0 до 100")]
        public double Procent { get; set; }

        [UIHint("Number")]
        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Период, месяц")]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше 1")]
        public int PeriodCount { get; set; }

        public override CalculateResult Calculate()
        {
            this.Procent *= PeriodCount / 12.0;
            double totalProcent = 0;
            double totalAmount = 0;
            object[,] resultTable = new object[PeriodCount + 2, 4];

            resultTable[0, 0] = "№";
            resultTable[0, 1] = "%";
            resultTable[0, 2] = "Основной долг";
            resultTable[0, 3] = "Всего";

            double balance = Amount;

            double payment = Payment();
            for (int i = 0; i < PeriodCount; i++)
            {
                double procent = balance * (Procent / 100) / PeriodCount;
                double mainDebt = payment - procent;
                balance -= mainDebt;

                resultTable[i + 1, 0] = i + 1;
                resultTable[i + 1, 1] = procent.ToString("f2");
                resultTable[i + 1, 2] = mainDebt.ToString("f2");
                resultTable[i + 1, 3] = (mainDebt + procent).ToString("f2");

                totalProcent += procent;
                totalAmount += mainDebt + procent;
            }

            int lastIndex = PeriodCount + 1;
            resultTable[lastIndex, 0] = "Итого:";
            resultTable[lastIndex, 1] = totalProcent.ToString("f2");
            resultTable[lastIndex, 2] = Amount.ToString("f2");
            resultTable[lastIndex, 3] = totalAmount.ToString("f2");

            return new CalculateResult
            {
                Result = resultTable,
                ResultType = ResultType.Table
            };
        }

        private double Payment()
        {
            double procent = (Procent / 100) / PeriodCount;
            double payment = Amount * (procent + procent / (Math.Pow(1 + procent, PeriodCount) - 1));
            return payment;
        }
    }
}
