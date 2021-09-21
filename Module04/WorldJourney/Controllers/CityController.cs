using System.IO;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using WorldJourney.Models;

namespace WorldJourney.Controllers
{
    public class CityController : Controller
    {
        private readonly IData _data;
        private readonly IWebHostEnvironment _environment;

        public CityController(IData data, IWebHostEnvironment environment)
        {
            _data = data ?? throw new System.ArgumentNullException(nameof(data));
            _environment = environment ?? throw new System.ArgumentNullException(nameof(environment));

            _data.CityInitializeData();
        }

        public IActionResult Index()
        {
            ViewData["Page"] = "Search city";

            return View();
        }

        public IActionResult Details(int? id)
        {
            ViewData["Page"] = "Search city";

            var city = _data.GetCityById(id);

            if (city == null) return NotFound();
            
            ViewBag.Title = city.CityName;

            return View(city);
        }

        public IActionResult GetImage(int? cityId)
        {
            ViewData["Message"] = "Display Image";

            var requestedCity = _data.GetCityById(cityId);
            if (requestedCity != null)
            {
                var webRootpath = _environment.WebRootPath;
                var folderPath = "images";
                var fullPath = Path.Combine(webRootpath, folderPath, requestedCity.ImageName);
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
