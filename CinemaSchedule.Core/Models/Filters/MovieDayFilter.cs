using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSchedule.Core.Models.Filters
{
    /// <summary>
    /// Динамическмй фильтр для расписания кинотеатров
    /// </summary>
    public class MovieDayFilter : ISearchFilter<MovieDay>
    {
        [DisplayName("Дата")]
        public DateTime? ScheduleDate { get; set; }

        [DisplayName("Кинотеатр")]
        public int? TheatreId { get; set; }

        [DisplayName("Фильм")]
        public int? MovieId { get; set; }

        public IQueryable<MovieDay> GetSatisfied(IQueryable<MovieDay> queryable)
        {
            if (TheatreId.GetValueOrDefault() != default(int))
            {
                queryable = queryable.Where(x => x.TheatreId == TheatreId);
            }

            if (MovieId.GetValueOrDefault() != default(int))
            {
                queryable = queryable.Where(x => x.MovieId == MovieId);
            }

            if (ScheduleDate > default(DateTime))
            {
                queryable = queryable.Where(x => x.Date.Date == ScheduleDate);
            }

            return queryable;
        }
    }
}
