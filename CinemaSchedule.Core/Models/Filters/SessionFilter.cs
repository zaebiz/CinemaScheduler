using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSchedule.Core.Models.Filters
{
    /// <summary>
    /// Динамическмй фильтр для поиска сеансов
    /// </summary>
    public class SessionFilter : ISearchFilter<Session>
    {
        public int? MovieDayId { get; set; }

        public IQueryable<Session> GetSatisfied(IQueryable<Session> queryable)
        {
            if (MovieDayId.GetValueOrDefault() != default(int))
            {
                queryable = queryable.Where(x => x.MovieDayId == MovieDayId);
            }

            return queryable;
        }
    }
}
