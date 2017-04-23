using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CinemaSchedule.Core.Models;
using CinemaSchedule.Core.Services;
using CinemaSchedule.Core.ViewModels;

namespace Cinema.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILookupService _lookupSvc;
        private readonly IDataService<MovieDay> _scheduleSvc;

        public AdminController(ILookupService lookupSvc, IDataService<MovieDay> scheduleSvc )
        {
            _lookupSvc = lookupSvc;
            _scheduleSvc = scheduleSvc;
        }

        // GET: Admin
        public async Task<ActionResult> Index()
        {
            var model = await _scheduleSvc.GetList();
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> MovieDayDetails(int dayId = 0)
        {
            var model = new MovieDayViewModel()
            {
                MovieDay = await _scheduleSvc.GetItem(dayId),
                TheatreList = await _lookupSvc.GetTheatresLookup(),
                MovieList = await _lookupSvc.GetMoviesLookup()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MovieDayDetails(MovieDayViewModel model)
        {
            if (ModelState.IsValid)
            {
                var day = await _scheduleSvc.UpdateItem(model.MovieDay);
            }

            return RedirectToAction("MovieDayDetails", new {dayId = model.MovieDay.Id});
        }
    }
}