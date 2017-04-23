using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private readonly MovieDataService _movieSvc;

        public MovieDayDataService(ApplicationDbContext ctx, MovieDataService movieSvc) : base(ctx)
        {
            _movieSvc = movieSvc;
        }

        protected override IQueryable<MovieDay> GetQueryable()
        {
            return _ctx.MovieDays
                .Include(x => x.Movie)
                .Include(x => x.Theatre)
                .Include(x => x.Sessions);
        }

        /// <summary>
        /// метод для кастомной валидации кинодня
        /// </summary>
        private async Task ValidateMovieDay(MovieDay newMovieDay)
        {
            var movie = await _movieSvc.GetItem(newMovieDay.MovieId);
            if (movie.ReleaseDate > newMovieDay.Date)
                throw new ValidationException($"Фильм не выйдет в прокат до {movie.ReleaseDate.ToShortDateString()} ");
        }

        public override async Task<MovieDay> AddItem(MovieDay item)
        {
            await ValidateMovieDay(item);
            return await base.AddItem(item);
        }
    }
}
