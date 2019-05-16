using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [HttpGet]
        [StatesLogging]
        public ActionResult MyContact()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        public ActionResult UpdateContact()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        public ActionResult DeleteContact()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        public ActionResult RegisterContact() {
            return View();
        }

        // POST: Contact
    }
}