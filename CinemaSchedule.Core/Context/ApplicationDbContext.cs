using System.Data.Entity;
using System.Runtime.CompilerServices;
using CinemaSchedule.Core.Models;

namespace CinemaSchedule.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new CinemaDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieDay> MovieDays { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<MovieRatingLookup> LookupRatings { get; set; }
    }
}