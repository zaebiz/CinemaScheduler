using System.Threading.Tasks;
using CinemaSchedule.Core.Context;
using CinemaSchedule.Core.Models;

namespace CinemaSchedule.Services.Data
{
    /// <summary>
    /// CRUD сервис фильмов
    /// </summary>
    public class MovieDataService : DataServiceBase<Movie>
    {
        public MovieDataService(ApplicationDbContext ctx) : base(ctx)
        {
        }
    }
}
