using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSchedule.Core.Context;
using CinemaSchedule.Core.Models;

namespace CinemaSchedule.Services
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
