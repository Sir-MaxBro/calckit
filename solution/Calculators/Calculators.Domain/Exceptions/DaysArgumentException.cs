using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculators.Domain.Exceptions
{
    [Serializable]
    internal class DaysArgumentException : ApplicationException
    {
        public DaysArgumentException(string message)
            : base(message)
        { }
    }
}
