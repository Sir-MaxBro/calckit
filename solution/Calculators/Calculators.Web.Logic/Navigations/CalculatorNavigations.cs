using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Calculators.Domain.Attributes;
using Calculators.Domain.Helpers;
using Calculators.Web.Logic.Entities;

namespace Calculators.Web.Logic.Navigations
{
    public static class CalculatorNavigations
    {
        private static CalculatorNavViewModel _calcModel;
        private static readonly string namespaceName = "Calculators.Domain.Calculators";

        static CalculatorNavigations()
        {
            _calcModel = new CalculatorNavViewModel();
            _calcModel.Calculators = new Dictionary<string, IDictionary<string, string>>();

            var calculatorsName = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(x => x.GetTypes())
                       .Where(x => x.IsClass && x.Namespace == namespaceName);

            var attributes = GetAttributeOfCalculators()
                .GroupBy(x => x.Category)
                .OrderBy(x => x.Key);

            foreach (var item in attributes)
            {
                var calculators = new Dictionary<string, string>();
                foreach (var calculator in item)
                {
                    calculators.Add(calculator.Type, calculator.Name);
                }

                _calcModel.Calculators.Add(item.Key, calculators);
            }
        }

        public static IDictionary<string, string> GetCalculatorOfCategory(string categoryName)
        {
            var calculators = new Dictionary<string, string>();
            var attributes = GetAttributeOfCalculators()
                .Where(x => x.Category == categoryName);
            foreach (var item in attributes)
            {
                calculators.Add(item.Type, item.Name);
            }
            return calculators;
        }

        private static IEnumerable<CalculatorAttribute> GetAttributeOfCalculators()
        {
            var calculatorsName = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(x => x.GetTypes())
                       .Where(x => x.IsClass && x.Namespace == namespaceName);
            return calculatorsName.Select(x => x.GetAttributeOfType<CalculatorAttribute>());
        }

        public static CalculatorNavViewModel Navs
        {
            get { return _calcModel; }
        }
    }
}