using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class GroupPersonsController : Controller
    {

        private Services.grupopersonaService GroupPersonsrv = new Services.grupopersonaService();
        // GET: Profile
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateGroupPerson")]
        public PartialViewResult CreateGroupPerson()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateGroupPerson")]
        public ActionResult UpdateGroupPerson(int? group, int? student)
        {
            if (group == null && student == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteGroupPerson")]
        public ActionResult DeleteGroupPerson()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetGroupPersons")]
        public PartialViewResult GetGroupPerson()
        {
            //Acomodar para que dependiendo el grupo elegido se muestren los alumnos
            return PartialView(GroupPersonsrv.listGrupPersons(0));
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetGroupPersons")]
        public ActionResult SpecifyGroupPersons()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateGroupPersons")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAuthors(Models.grupopersonaModel gpm)
        {
            if (ModelState.IsValid)
            {
                if (GroupPersonsrv.CreateGrupPerson(gpm))
                    return RedirectToAction("getGroupPerson");
                else
                    return View(gpm);
            }
            return View();


        }
    }
}