using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Calculators.Domain.Entities.Enums
{
    public enum Square : long
    {
        [Display(Name = "Квадратный метр")]
        SquareMeter = 100 * 10000,

        [Display(Name = "Квадратный километр")]
        SquareKilometer = (long)(0.0001 * 10000),

        [Display(Name = "Гектар")]
        Hectare = (long)(0.01 * 10000),

        [Display(Name = "Ар (сотка)")]
        Ar = 1 * 10000,

        [Display(Name = "Квадратный дециметр")]
        SquareDecimeter = 10000 * 10000,

        [Display(Name = "Квадратный сантиметр")]
        SquareCentimeter = 1000000L * 10000L
    }
}
