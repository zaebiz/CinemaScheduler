using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CinemaSchedule.Core.Context;
using CinemaSchedule.Core.Models;

namespace CinemaSchedule.Services.Data
{
    /// <summary>
    /// CRUD сервис кинодней
    /// </summary>
    class MovieDayDataService : DataServiceBase<MovieDay>
    {
        public MovieDayDataService(ApplicationDbContext ctx) : base(ctx)
        {
        }

        protected override IQueryable<MovieDay> GetQueryable()
        {
            return _ctx.MovieDays
                .Include(x => x.Movie)
                .Include(x => x.Theatre)
                .Include(x => x.Sessions);
        }
    }
}
