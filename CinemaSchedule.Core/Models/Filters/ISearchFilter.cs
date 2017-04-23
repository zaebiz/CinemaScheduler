using System;
using System.Linq;
using System.Linq.Expressions;

namespace CinemaSchedule.Core.Models.Filters
{
    /// <summary>
    /// интерфейс для построения предикатов фильтрации
    /// </summary>
    public interface ISearchFilter<T>
    {
        IQueryable<T> GetSatisfied(IQueryable<T> queryable);
    }

}
