using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSchedule.Core.Models;

namespace CinemaSchedule.Core.ViewModels
{
    /// <summary>
    /// Модель формы создания редактирования расписания на день
    /// </summary>
    public class MovieDayViewModel
    {
        public List<Lookup> TheatreList { get; set; }
        public List<Lookup> MovieList { get; set; }

        public MovieDay MovieDay { get; set; }
    }
}
