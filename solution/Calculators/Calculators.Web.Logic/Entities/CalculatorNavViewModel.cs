using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculators.Web.Logic.Entities
{
    public class CalculatorNavViewModel
    {
        public IDictionary<string, IDictionary<string, string>> Calculators { get; set; }
    }
}
