using Microsoft.AspNetCore.Mvc;

namespace WorldJourney.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
