using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaSchedule.Core.Services
{
    /// <summary>
    /// базовый интерфейс сервиса работы с данными
    /// </summary>
    public interface IDataService<T>
    {
        Task<T> GetItem(int id);
        Task<List<T>> GetList();
        Task<T> AddItem(T item);
        Task<T> UpdateItem(T item);
        Task DeleteItem(T item);
    }
}
