using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculators.Domain.Entities.Enums;

namespace Calculators.Domain.Entities
{
    public class CalculateResult
    {
        public object Result { get; internal set; }

        public object Value { get; internal set; }

        public ResultType ResultType { get; internal set; }
    }
}
