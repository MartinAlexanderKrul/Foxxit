﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Controllers
{
    public class HomeController : Controller
    {
        // public Service Service { get; private set; }

        public HomeController(/*Service service*/)
        {
            // Service = service;
        }

        [HttpGet("index")]
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("index");
        }
    }
}