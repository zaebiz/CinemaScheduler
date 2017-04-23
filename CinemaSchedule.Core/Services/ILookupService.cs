using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSchedule.Core.Models;

namespace CinemaSchedule.Core.Services
{
    /// <summary>
    /// сервис получения / генерации словарей (в едином формате для клиента)
    /// </summary>
    public interface ILookupService
    {
        Task<List<Lookup>> GetTheatresLookup();
        Task<List<Lookup>> GetMoviesLookup();
    }
}
