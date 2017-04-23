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
        private readonly IDataService<MovieDay> _scheduleSvc;
        private readonly ILookupService _lookupSvc;

        public HomeController(IDataService<MovieDay> scheduleSvc, ILookupService lookupSvc)
        {
            _scheduleSvc = scheduleSvc;
            _lookupSvc = lookupSvc;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Schedule");
        }

        //[AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        [HttpGet]
        public async Task<ActionResult> Schedule()
        {           
            var model = new ScheduleViewModel()
            {
                Filter = new MovieDayFilter()
            };

            model = await CreateSchedule(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Schedule(ScheduleViewModel model)
        {
            if (ModelState.IsValid)
                model = await CreateSchedule(model);

            return View(model);
        }

        [NonAction]
        public async Task<ScheduleViewModel> CreateSchedule(ScheduleViewModel model)
        {
            model.TheatreList = await _lookupSvc.GetTheatresLookup();
            model.MovieList = await _lookupSvc.GetMoviesLookup();

            model.Schedule = (await _scheduleSvc.GetList(model.Filter))
                .GroupBy(x => x.Theatre.Name)
                .ToDictionary(x => x.Key, y => y.ToList());

            return model;
        }


    }
}