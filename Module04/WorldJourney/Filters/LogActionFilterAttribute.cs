﻿using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WorldJourney.Filters
{
    public class LogActionFilterAttribute: ActionFilterAttribute
    {
        private readonly IWebHostEnvironment _environment;
        
        private readonly string _contentRootPath;
        private readonly string _logPath;
        private readonly string _fileName;
        private readonly string _fullPath;

        public LogActionFilterAttribute(IWebHostEnvironment environment)
        {
            _environment = environment ?? throw new System.ArgumentNullException(nameof(environment));

            _contentRootPath = environment.ContentRootPath;
            _logPath = Path.Combine(_contentRootPath, "LogFile");
            _fileName = $"log {DateTime.Now:MM-dd-yyyy-H-mm}.txt";
            _fullPath = Path.Combine(_logPath, _fileName);
        }

    }
}
