using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Index()
        {
            return RedirectToAction("Error");
        }

        public ActionResult Error(string msg)
        {
            ViewBag.ErrorMessage = msg;
            return View();
        }
    }
}