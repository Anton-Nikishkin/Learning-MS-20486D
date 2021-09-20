using System;
using System.Collections.Generic;

using CakeStoreApi.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CakeStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakeStoreApiController : ControllerBase
    {
        private IData _data;
        private readonly ILogger<CakeStoreApiController> _logger;

        public CakeStoreApiController(ILogger<CakeStoreApiController> logger, IData data)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        [HttpGet("/api/CakeStore")]
        public ActionResult<List<CakeStore>> GetAll()
        {
            return _data.CakesInitializeData();
        }

        [HttpGet("/api/CakeStore/{id}", Name = "GetCake")]
        public ActionResult<CakeStore> GetById(int? id)
        {
            var item = _data.GetCakeById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}