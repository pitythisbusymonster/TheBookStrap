﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBookStrap.Controllers
{
    public class HabitTrackerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
