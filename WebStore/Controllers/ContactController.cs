﻿using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
