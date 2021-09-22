﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CitiesWebsite.Services;

namespace CitiesWebsite.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityProvider _cities;

        public CityController(ICityProvider cities)
        {
            _cities = cities;
        }

        public IActionResult ShowCities()
        {
            ViewBag.Cities = _cities;

            return View();
        }

        public IActionResult ShowDataForCity()
        {
            return View();
        }

        public IActionResult GetImage(string cityName)
        {
            return Content(cityName);
        }
    }
}