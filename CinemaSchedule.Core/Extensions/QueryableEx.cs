using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSchedule.Core.Models.Filters;

namespace CinemaSchedule.Core.Extensions
{
    /// <summary>
    /// методы расширения для IQueryable
    /// </summary>
    public static class QueryableEx
    {
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> queryable, ISearchFilter<T> filter)
        {
            if (filter != null)
                queryable = filter.GetSatisfied(queryable);

            return queryable;
        }
    }
}
