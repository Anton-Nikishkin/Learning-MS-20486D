using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ShirtStoreWebsite.Models;
using ShirtStoreWebsite.Services;

namespace ShirtStoreWebsite.Controllers
{
    public class ShirtController : Controller
    {
        private readonly IShirtRepository _repository;
        private readonly ILogger _logger;

        public ShirtController(IShirtRepository repository, ILogger logger)
        {
            _repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddShirt(Shirt shirt)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}