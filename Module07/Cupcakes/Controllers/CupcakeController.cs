using System;
using System.IO;

using Cupcakes.Models;
using Cupcakes.Repositories;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Cupcakes.Controllers
{
    public class CupcakeController : Controller
    {
        private readonly ICupcakeRepository _repository;
        private readonly IWebHostEnvironment _environment;

        public CupcakeController(ICupcakeRepository repository, IWebHostEnvironment environment)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetImage(int id)
        {
            Cupcake requestedCupcake = _repository.GetCupcakeById(id);
            if (requestedCupcake != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedCupcake.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    return File(fileBytes, requestedCupcake.ImageMimeType);
                }
                else
                {
                    if (requestedCupcake.PhotoFile.Length > 0)
                    {
                        return File(requestedCupcake.PhotoFile, requestedCupcake.ImageMimeType);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}