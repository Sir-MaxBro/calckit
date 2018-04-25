using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Calculators.Domain.Entities.Enums
{
    public enum Gender
    {
        [Display(Name = "Мужской")]
        Man,

        [Display(Name = "Женский")]
        Woman
    }
}
