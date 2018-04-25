using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Calculators.Domain.Abstract;

namespace Calculators.Web.Models
{
    public class CalculatorViewModel
    {
        public Calculator Calculator { get; set; }

        public string Description { get; set; }

        public IDictionary<string, string> SimilarCalculators { get; set; }
    }
}