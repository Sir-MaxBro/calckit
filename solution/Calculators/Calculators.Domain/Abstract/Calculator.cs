using System.Web.Mvc;
using Calculators.Domain.Entities;

namespace Calculators.Domain.Abstract
{
    public abstract class Calculator
    {
        [HiddenInput(DisplayValue = false)]
        public string CalculatorName
        {
            get { return this.GetType().Name; }
        }

        public abstract CalculateResult Calculate();

        protected bool CheckNotNegative(double number)
        {
            if (number <= 0 || double.IsNaN(number))
            {
                return false;
            }
            return true;
        }
    }
}
