using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    [Authorize, RequireHttps]
    public class HomeController : Controller
    {
        [HttpGet, AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet, AllowAnonymous]
        public ActionResult productos()
        {
            return View();
        }
    }
}
