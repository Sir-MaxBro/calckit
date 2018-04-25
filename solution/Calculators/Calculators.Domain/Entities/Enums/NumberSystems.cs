using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Calculators.Domain.Entities.Enums
{
    public enum NumberSystems
    {
        [Display(Name = "Двоичная")]
        Binary = 2,

        [Display(Name = "Десятичная")]
        Decimal = 10,

        [Display(Name = "Шестнадцатиричная")]
        Hexadecimal = 16
    }
}
