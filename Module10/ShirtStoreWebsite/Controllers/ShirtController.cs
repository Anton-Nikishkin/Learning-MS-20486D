using Microsoft.AspNetCore.Mvc;

using ShirtStoreWebsite.Models;
using ShirtStoreWebsite.Services;

namespace ShirtStoreWebsite.Controllers
{
    public class ShirtController : Controller
    {
        private readonly IShirtRepository _repository;

        public ShirtController(IShirtRepository repository)
        {
            _repository = repository;
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