using System.IO;

using Microsoft.AspNetCore.Mvc;

using WorldJourney.Models;

namespace WorldJourney.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Page"] = "Search city";

            return View();
        }

        public IActionResult Details(int? id)
        {
            ViewData["Page"] = "Search city";

            City city = null;

            if (city == null) return NotFound();

            return View(city);
        }

        public IActionResult GetImage(int? cityId)
        {
            ViewData["Message"] = "Display Image";

            City requestedCity = null;
            if (requestedCity != null)
            {
                var fullPath = "";
                var fileOnDisk = new FileStream(fullPath, FileMode.Open);
                byte[] fileBytes;
                using (BinaryReader br = new BinaryReader(fileOnDisk))
                {
                    fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                }
                return File(fileBytes, requestedCity.ImageMimeType);

            }
            else
            {
                return NotFound();
            }
        }
    }
}
