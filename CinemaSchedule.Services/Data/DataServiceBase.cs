using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CinemaSchedule.Core.Context;
using CinemaSchedule.Core.Extensions;
using CinemaSchedule.Core.Models;
using CinemaSchedule.Core.Models.Filters;
using CinemaSchedule.Core.Services;

namespace CinemaSchedule.Services.Data
{
    /// <summary>
    /// базовый generic CRUD сервис работы с данными через контекст EF
    /// </summary>
    public class DataServiceBase<T> : IDataService<T> 
        where T : class, IDbEntity
    {
        protected readonly ApplicationDbContext _ctx;

        public DataServiceBase(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        protected virtual IQueryable<T> GetQueryable()
        {
            return _ctx.Set<T>();
        }

        public virtual async Task<T> GetItem(int id)
        {
            if (id <= default(int))
                throw new ArgumentOutOfRangeException($"Некорректный id = {id}");

            return await GetQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<List<T>> GetList(ISearchFilter<T> filter = null)
        {
            return await GetQueryable()
                .ApplyFilter(filter)
                .ToListAsync();
        }

        public virtual async Task<T> AddItem(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Не задан объект");

            _ctx.Set<T>().Add(item);
            await _ctx.SaveChangesAsync();

            return item;
        }

        public virtual async Task<T> UpdateItem(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Не задан объект");

            if (item.Id == default(int))
                throw new ArgumentOutOfRangeException($"Некорректный id = {item.Id}");

            _ctx.Set<T>().Attach(item);
            _ctx.Entry(item).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();

            return item;
        }

        public virtual async Task DeleteItem(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Не задан объект");

            _ctx.Set<T>().Remove(item);
            await _ctx.SaveChangesAsync();
        }
    }
}
