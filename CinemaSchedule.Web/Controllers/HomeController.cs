using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CinemaSchedule.Core.Context;
using CinemaSchedule.Core.Models;
using CinemaSchedule.Core.Models.Filters;
using CinemaSchedule.Core.Services;
using CinemaSchedule.Core.ViewModels;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService<Theatre> _theatreSvc;
        private readonly IDataService<Movie> _movieSvc;
        private readonly IDataService<MovieDay> _scheduleSvc;
        private readonly IMapper _mapper;

        public HomeController(IDataService<Theatre> theatreSvc, IDataService<Movie> movieSvc, IDataService<MovieDay> scheduleSvc, IMapper mapper)
        {
            _theatreSvc = theatreSvc;
            _movieSvc = movieSvc;
            _scheduleSvc = scheduleSvc;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Schedule");
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public async Task<ActionResult> Schedule(ScheduleViewModel model)
        {           
            if (model == null)
            {
                model = new ScheduleViewModel()
                {
                    Filter = new MovieDayFilter()
                };
            }

            model.TheatreList = (await _theatreSvc.GetList())
                .Select(x => _mapper.Map<Lookup>(x))
                .ToList();

            model.MovieList = (await _movieSvc.GetList())
                .Select(x => _mapper.Map<Lookup>(x))
                .ToList();

            model.Schedule = (await _scheduleSvc.GetList(model.Filter))
                .GroupBy(x => x.Theatre.Name)
                .ToDictionary(x => x.Key, y => y.ToList());

            return View(model);
        }
    }
}