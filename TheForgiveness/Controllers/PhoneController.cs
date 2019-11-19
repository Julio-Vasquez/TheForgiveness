using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class PhoneController : Controller
    {
        private Services.telefonoService Phonesrv = new Services.telefonoService();
        // GET: Activities
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreatePhone")]
        public PartialViewResult CreatePhone()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdatePhone")]
        public ActionResult UpdatePhone(int? id)
        {
            return View();
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeletePhone")]
        public ActionResult DeletePhone()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetPhones")]
        public PartialViewResult GetPhone()
        {
            return PartialView(Phonesrv.listphones());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetPhones")]
        public ActionResult SpecifyGetPhones()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreatePhones")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePhones(Models.telefonoModel tm)
        {
            if (ModelState.IsValid)
            {
                if (Phonesrv.CreatePhones(tm))
                    return RedirectToAction("getPhone");
                else
                    return View(tm);
            }
            return View();


        }
    }
}