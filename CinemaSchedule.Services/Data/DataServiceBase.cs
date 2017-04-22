using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using CinemaSchedule.Core.Context;
using CinemaSchedule.Core.Models;
using CinemaSchedule.Core.Services;

namespace CinemaSchedule.Services.Data
{
    /// <summary>
    /// базовый generic сервис работы с данными через контекст EF
    /// </summary>
    public class DataServiceBase<T> : IDataService<T> 
        where T : class, IDbEntity
    {
        protected readonly ApplicationDbContext _ctx;

        public DataServiceBase(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<T> GetItem(int id)
        {
            if (id <= default(int))
                throw new ArgumentOutOfRangeException($"Некорректный id = {id}");

            return await _ctx.Set<T>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> GetList()
        {
            return await _ctx.Set<T>().ToListAsync();
        }

        public async Task<T> AddItem(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Не задан объект");

            _ctx.Set<T>().Add(item);
            await _ctx.SaveChangesAsync();

            return item;
        }

        public async Task<T> UpdateItem(T item)
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

        public async Task DeleteItem(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Не задан объект");

            _ctx.Set<T>().Remove(item);
            await _ctx.SaveChangesAsync();
        }
    }
}
