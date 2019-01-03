using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult MyContact()
        {
            return View();
        }

        public ActionResult UpdateContact()
        {
            return View();
        }

        public ActionResult DeleteContact()
        {
            return View();
        }

        public ActionResult RegisterContact() {
            return View();
        }

        // POST: Contact
    }
}