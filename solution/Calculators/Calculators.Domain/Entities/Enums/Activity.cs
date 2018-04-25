using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Calculators.Domain.Entities.Enums
{
    public enum Activity
    {
        [Display(Name = "Минимальные нагрузки (сидячая работа)")]
        Training0 = 12,

        [Display(Name = "Необременительные тренировки 3 раза в неделю")]
        Training3 = 13,

        [Display(Name = "Тренировки 5 раз в неделю (работа средней тяжести)")]
        Training5 = 14,

        [Display(Name = "Интенсивные тренировки 5 раз в неделю")]
        Training5Full = 15,

        [Display(Name = "Ежедневные тренировки")]
        TrainingEveryDay = 16,

        [Display(Name = "Ежедневные интенсивные тренировки или занятия 2 раза в день")]
        TrainingEveryDay2 = 17,

        [Display(Name = "Интенсивные тренировки 2 раза в день")]
        WorkAndTrainingEveryDay = 19
    }
}
