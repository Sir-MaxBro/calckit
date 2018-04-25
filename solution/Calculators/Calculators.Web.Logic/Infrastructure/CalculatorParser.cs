using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculators.Web.Logic.Serialize;
using Calculators.Domain.Abstract;
using iMax.HtmlConverter;
using Calculators.Domain.Entities.Enums;
using Calculators.Web.Logic.Factory;
using Calculators.Domain.Calculators;

namespace Calculators.Web.Logic.Infrastructure
{
    public class CalculatorParser
    {
        private string _json;
        private Calculator _calculator;
        public CalculatorParser(string json)
        {
            _json = json;
        }

        public string GetCalculateHtmlValue()
        {
            string resultHtml = "";

            var calculator = JSONSerializeConvert.DeserializeCalculator(_json) as Calculator;

            var calcResult = calculator.Calculate();

            IHtmlConverter converter = new HtmlConverter();

            switch (calcResult.ResultType)
            {
                case ResultType.Table:
                    resultHtml = converter.ConvertToHtml(calcResult.Result, "result-table");
                    break;
                case ResultType.Article:
                    resultHtml = converter.ConvertToHtml(calcResult.Result);
                    break;
                default:
                    resultHtml = "";
                    break;
            }

            return resultHtml;
        }
    }
}
