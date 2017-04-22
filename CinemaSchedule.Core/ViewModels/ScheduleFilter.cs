using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSchedule.Core.ViewModels
{
    public class ScheduleFilter
    {
        [DisplayName("Дата")]
        public DateTime? ScheduleDate { get; set; }

        [DisplayName("Кинотеатр")]
        public int? TheatreId { get; set; }

        [DisplayName("Фильм")]
        public int? MovieId { get; set; }
    }
}
