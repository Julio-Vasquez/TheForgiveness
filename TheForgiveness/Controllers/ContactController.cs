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
        [PermissionAttributes(File = "MyContact")]
        public PartialViewResult MyContact()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateContact")]
        public ActionResult UpdateContact()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteContact")]
        public ActionResult DeleteContact()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "RegisterContact")]
        public PartialViewResult RegisterContact() {
            return PartialView();
        }

        // POST: Contact
    }
}