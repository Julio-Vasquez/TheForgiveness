﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class AuthorsController : Controller
    {
        private Util.Util util = new Util.Util();
        // GET: Profile
        [HttpGet]
        public ActionResult CreateAuthors()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Error404", "Shared");
            }
        }

        public ActionResult UpdateAuthors()
        {
            return View();
        }

        public ActionResult DeleteAuthors()
        {
            return View();
        }
        public ActionResult GetAuthors()
        {
            return View();
        }
    }
}