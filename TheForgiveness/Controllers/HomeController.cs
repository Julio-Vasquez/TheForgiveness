﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(int id)
        {
            //logic
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }


    }
}