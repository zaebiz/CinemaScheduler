using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSchedule.Core.Models;
using CinemaSchedule.Core.Models.Filters;

namespace CinemaSchedule.Core.ViewModels
{
    /// <summary>
    /// ViewModel для страницы отображения расписания
    /// </summary>
    public class ScheduleViewModel
    {
        public Dictionary<string, List<MovieDay>> Schedule { get; set; }

        public List<Lookup> TheatreList { get; set; }
        public List<Lookup> MovieList { get; set; }
        public MovieDayFilter Filter { get; set; }
    }
}
