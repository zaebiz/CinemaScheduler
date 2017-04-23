using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CinemaSchedule.Core.Models;
using CinemaSchedule.Core.Models.Filters;
using CinemaSchedule.Core.Services;
using CinemaSchedule.Core.ViewModels;

namespace Cinema.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILookupService _lookupSvc;
        private readonly IDataService<MovieDay> _scheduleSvc;
        private readonly IDataService<Session> _sessionSvc;

        public AdminController(ILookupService lookupSvc, IDataService<MovieDay> scheduleSvc, IDataService<Session> sessionSvc  )
        {
            _lookupSvc = lookupSvc;
            _scheduleSvc = scheduleSvc;
            _sessionSvc = sessionSvc;
        }

        // GET: Admin
        public async Task<ActionResult> Index()
        {
            var model = (await _scheduleSvc.GetList())
                .OrderBy(x => x.TheatreId)
                .ThenBy(x => x.Date)
                .ToList();

            return View(model);
        }

        [NonAction]
        public async Task<MovieDayViewModel> PrepareMovieDayViewModel()
        {
            var model = new MovieDayViewModel()
            {
                MovieDay = new MovieDay()
                {
                    Date = DateTime.Now.Date,
                    Sessions = new List<Session>()
                },
                TheatreList = await _lookupSvc.GetTheatresLookup(),
                MovieList = await _lookupSvc.GetMoviesLookup()
            };

            return model;
        }

        [HttpGet]
        public async Task<ActionResult> MovieDayDetails(int dayId = 0)
        {
            var model = await PrepareMovieDayViewModel();
            if (dayId > 0)
            {
                model.MovieDay = await _scheduleSvc.GetItem(dayId);

                if (model.MovieDay == null)
                    throw new ArgumentOutOfRangeException(nameof(dayId), "Не найден выбраный день");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MovieDayDetails(MovieDayViewModel post)
        {
            if (ModelState.IsValid)
            {
                MovieDay movieDay = null;
                if (post.MovieDay.Id > default(int))
                    movieDay = await _scheduleSvc.UpdateItem(post.MovieDay);
                else
                    movieDay = await _scheduleSvc.AddItem(post.MovieDay);

                return RedirectToAction("MovieDayDetails", new {dayId = movieDay.Id});
            }

            var model = await PrepareMovieDayViewModel();
            model.MovieDay = await _scheduleSvc.GetItem(post.MovieDay.Id);

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> SessionDetails(int movieDayId, int sessionId = 0)
        {
            var session = new Session()
            {
                MovieDayId = movieDayId,
                StartTime = "11:00",
            };

            if (sessionId > default(int))
            {
                session = await _sessionSvc.GetItem(sessionId);
                if (session == null)
                    throw new ArgumentOutOfRangeException(nameof(sessionId), "Не найден требуемый сеанс");
            }
            
            return View(session);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SessionDetails(Session model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id > default(int))
                    model = await _sessionSvc.UpdateItem(model);
                else
                    model = await _sessionSvc.AddItem(model);

                return RedirectToAction("MovieDayDetails", new {dayId = model.MovieDayId});
            }

            return View(model);
        }

        [HttpGet]        
        public async Task<ActionResult> DeleteSession(int sessionId)
        {
            var session = await _sessionSvc.GetItem(sessionId);
            await _sessionSvc.DeleteItem(session);

            return RedirectToAction("MovieDayDetails", new {dayId = session.MovieDayId});
        }


    }
}