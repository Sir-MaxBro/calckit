using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Unity;
using Calculators.Domain.Calculators;
using Calculators.Domain.Abstract;

namespace Calculators.Web.Logic.Factory
{
    public static class CalculatorFactory
    {
        private static UnityContainer _container;
        private static readonly string _namespaceName = "Calculators.Domain.Calculators";

        static CalculatorFactory()
        {
            _container = new UnityContainer();
            Binding();
        }

        private static void Binding()
        {
            var calculatorsName = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(x => x.GetTypes())
                       .Where(x => x.IsClass && x.Namespace == _namespaceName);

            foreach (var item in calculatorsName)
            {
                AddBinding(item);
            }
        }

        private static void AddBinding(Type type)
        {
            _container.RegisterType(typeof(Calculator), type, type.Name, null);
        }

        public static Calculator GetCalculate(string calculateName)
        {
            return _container.Resolve<Calculator>(calculateName);
        }
    }
}