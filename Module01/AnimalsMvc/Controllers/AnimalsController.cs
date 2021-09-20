using System.Collections.Generic;

using AnimalsMvc.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnimalsMvc.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly ILogger<AnimalsController> _logger;

        private readonly IData _tempData;

        public AnimalsController(ILogger<AnimalsController> logger, IData tempData)
        {
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            _tempData = tempData ?? throw new System.ArgumentNullException(nameof(tempData));
        }

        public IActionResult Index()
        {
            List<Animal> animals = _tempData.AnimalsInitializeData();

            var indexViewModel = new IndexViewModel
            {
                Animals = animals
            };

            return View(indexViewModel);
        }

        public IActionResult Details(int? id)
        {
            var model = _tempData.GetAnimalById(id);
            
            return model == null ? NotFound() : (IActionResult)View(model);
        }
    }
}