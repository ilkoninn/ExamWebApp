﻿using Microsoft.AspNetCore.Mvc;

namespace ExamWebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
