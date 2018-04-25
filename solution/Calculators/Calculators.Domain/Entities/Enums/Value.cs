using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Calculators.Domain.Entities.Enums
{
    public enum Value : int
    {
        [Display(Name = "Кубический метр")]
        Cbm = (int)(0.001 * 100000),

        [Display(Name = "Кубический сантиметр")]
        Ccm = 1000 * 100000,

        [Display(Name = "Гектометр")]
        Hm = (int)(0.01 * 100000),

        [Display(Name = "Декалитр")]
        Decaliter = (int)(0.1 * 100000),

        [Display(Name = "Литр")]
        Liter = 1 * 100000,

        [Display(Name = "Децилитр")]
        Deciliter = 10 * 100000,

        [Display(Name = "Сантилитр")]
        Centiliter = 100 * 100000,

        [Display(Name = "Баррель")]
        Bbl = (int)(0.00629 * 100000),

        [Display(Name = "Галлон")]
        Gal = (int)(0.2641 * 100000),

        [Display(Name = "Пинта")]
        Pt = (int)(2.1133 * 100000),

        [Display(Name = "Жидкая унция")]
        LiquidOunce = (int)(33.814 * 100000)
    }
}
