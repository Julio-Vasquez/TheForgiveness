using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class CalificationController : Controller
    {
        private Services.notasService Calificationssrv = new Services.notasService();
        // GET: Activities
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateCalification")]
        public PartialViewResult CreateCalification()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateCalification")]
        public ActionResult UpdateCalification(int? id)
        {
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteCalification")]
        public ActionResult DeleteCalification()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetCalifications")]
        public PartialViewResult GetCalification()
        {
            return PartialView(Calificationssrv.listCalifications());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetCalifications")]
        public ActionResult SpecifyGetCalifications()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateCalifications")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCalifications(Models.notasModel nm)
        {
            if (ModelState.IsValid)
            {
                if (Calificationssrv.CreateCalifications(nm))
                    return RedirectToAction("getCalification");
                else
                    return View(nm);
            }
            return View();


        }
    }
}