using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CinemaSchedule.Core.Models;
using CinemaSchedule.Core.Services;

namespace CinemaSchedule.Services.Data
{
    /// <summary>
    /// сервис получения / генерации словарей (в едином формате для клиента)
    /// </summary>    
    public class LookupService : ILookupService
    {
        private readonly IDataService<Theatre> _theatreSvc;
        private readonly IDataService<Movie> _movieSvc;
        private readonly IMapper _mapper;

        public LookupService(IDataService<Theatre> theatreSvc, IDataService<Movie> movieSvc, IMapper mapper)
        {
            _theatreSvc = theatreSvc;
            _movieSvc = movieSvc;
            _mapper = mapper;
        }

        public async Task<List<Lookup>> GetTheatresLookup()
        {
            return (await _theatreSvc.GetList())
                .Select(x => _mapper.Map<Lookup>(x))
                .ToList();
        }

        public async Task<List<Lookup>> GetMoviesLookup()
        {
            return (await _movieSvc.GetList())
                .Select(x => _mapper.Map<Lookup>(x))
                .ToList();
        }
    }
}
