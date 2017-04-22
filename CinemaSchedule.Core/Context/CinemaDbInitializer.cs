using System;
using System.Collections.Generic;
using System.Data.Entity;
using CinemaSchedule.Core.Models;

namespace CinemaSchedule.Core.Context
{
    class CinemaDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // возрастной рейтинг
            var rating1 = new MovieRatingLookup() {Name = "4+", Value = 4};
            var rating2 = new MovieRatingLookup() { Name = "12+", Value = 12 };
            var rating3 = new MovieRatingLookup() { Name = "18+", Value = 18 };
            var ratingList = new List<MovieRatingLookup>() {rating1, rating2, rating3};
            context.LookupRatings.AddRange(ratingList);

            // кинотеатры
            var cinama1 = new Theatre()
            {
                Name = "Октябрь",
                MaxSpectatorsCount = 100,
            };
            var cinama2 = new Theatre()
            {
                Name = "Родина",
                MaxSpectatorsCount = 100,
            };

            context.Theatres.Add(cinama1);
            context.Theatres.Add(cinama2);

            // фильмы
            var movie1 = new Movie()
            {
                Name = "Форсаж 8",
                ReleaseDate = DateTime.Now.Date.AddDays(-1),
                MovieRatingLookup = rating3
            };
            var movie2 = new Movie()
            {
                Name = "Стражи галактики 2",
                ReleaseDate = DateTime.Now.Date.AddDays(10),
                MovieRatingLookup = rating2
            };
            var movie3 = new Movie()
            {
                Name = "Аватар",
                ReleaseDate = DateTime.Now.Date.AddYears(-5),
                MovieRatingLookup = rating2
            };
            var movie4 = new Movie()
            {
                Name = "Время первых",
                ReleaseDate = DateTime.Now.Date.AddYears(-5),
                MovieRatingLookup = rating1
            };

            var movieList = new List<Movie>() {movie1, movie2, movie3, movie4};
            context.Movies.AddRange(movieList);

            // дефолтное расписание
            var day1 = new MovieDay()
            {
                Theatre = cinama1,
                Movie = movie1,
                Date = DateTime.Now.Date,
            };
            var day2 = new MovieDay()
            {
                Theatre = cinama2,
                Movie = movie3,
                Date = DateTime.Now.Date,
            };
            var day3 = new MovieDay()
            {
                Theatre = cinama1,
                Movie = movie3,
                Date = DateTime.Now.Date.AddDays(1),
            };

            var range = new List<MovieDay>() {day1, day2, day3};
            context.MovieDays.AddRange(range);

        }
    }
}
