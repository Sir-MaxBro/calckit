using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculators.Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using Calculators.Domain.Attributes;
using Calculators.Domain.Exceptions;
using Calculators.Domain.Entities;
using Calculators.Domain.Entities.Enums;

namespace Calculators.Domain.Calculators
{
    [Calculator("Разное", "Калькулятор дат", "Days")]
    public class Days : Calculator
    {
        [Required(ErrorMessage = "Введите значение.")]
        [Display(Name = "Начальная дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Введите значение.")]
        [Display(Name = "Конечная дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public override CalculateResult Calculate()
        {
            if (StartDate > EndDate)
            {
                throw new DaysArgumentException("The StartDate is more than EndDate.");
            }

            IDictionary<object, object> resultRanges = new Dictionary<object, object>();
            TimeSpan differenceDate = EndDate - StartDate;
            resultRanges.Add("Интервал", "Значение");

            resultRanges.Add("Год", (differenceDate.TotalDays / 365).ToString("f2"));
            resultRanges.Add("Неделя", (differenceDate.TotalDays / 7).ToString("f2"));
            resultRanges.Add("День", differenceDate.TotalDays);
            resultRanges.Add("Час", differenceDate.TotalHours);
            resultRanges.Add("Минута", differenceDate.TotalMinutes);
            resultRanges.Add("Секунда", differenceDate.TotalSeconds);

            return new CalculateResult { Result = resultRanges, ResultType = ResultType.Table };
        }
    }
}
