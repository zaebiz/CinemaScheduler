using CinemaSchedule.Core.Context;
using CinemaSchedule.Core.Models;

namespace CinemaSchedule.Services.Data
{
    /// <summary>
    /// CRUD сервис кинотеатров
    /// </summary>
    public class TheatreDataService : DataServiceBase<Theatre>
    {
        public TheatreDataService(ApplicationDbContext ctx) : base(ctx)
        {
        }
    }
}
