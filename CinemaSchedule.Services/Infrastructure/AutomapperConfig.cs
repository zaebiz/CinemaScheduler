using AutoMapper;
using CinemaSchedule.Core.Models;

namespace CinemaSchedule.Services.Infrastructure
{
    public class AutomapperConfig
    {
        public static MapperConfiguration CreateMapping()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Theatre, Lookup>();
                cfg.CreateMap<Movie, Lookup>();
            });
        }
    }
}