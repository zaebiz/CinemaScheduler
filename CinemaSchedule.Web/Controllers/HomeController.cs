using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CinemaSchedule.Core.Context;
using CinemaSchedule.Core.Models;
using CinemaSchedule.Core.Services;
using CinemaSchedule.Core.ViewModels;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService<Theatre> _theatreSvc;
        private readonly IDataService<Movie> _movieSvc;
        private readonly IMapper _mapper;

        public HomeController(IDataService<Theatre> theatreSvc, IDataService<Movie> movieSvc,IMapper mapper)
        {
            _theatreSvc = theatreSvc;
            _movieSvc = movieSvc;
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
                    Filter = new ScheduleFilter()
                };
            }

            model.MovieList = (await _theatreSvc.GetList())
                .Select(x => _mapper.Map<Lookup>(x))
                .ToList();

            model.TheatreList = (await _movieSvc.GetList())
                .Select(x => _mapper.Map<Lookup>(x))
                .ToList();

            return View(model);
        }
    }
}