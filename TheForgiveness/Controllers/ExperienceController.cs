using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class ExperienceController : Controller
    {
        private Services.experienciaService Experiencesrv = new Services.experienciaService();
        // GET: Concept
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateExperience")]
        public PartialViewResult CreateExperience()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateExperience")]
        public ActionResult UpdateExperience(int? id)
        {
            if (id == null)
            {

            }
            return RedirectToAction("Error404", "Shared");
        }

        //[HttpGet]
        //[StatesLogging]
        //[PermissionAttributes(File = "DeleteExperience")]
        //public ActionResult DeleteExperience()
        //{
        //    return View();
        //}

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetExperiences")]
        public PartialViewResult GetExperiences()
        {
            return PartialView(Experiencesrv.listExperiencess());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetExperiences")]
        public ActionResult SpecifyExperiences()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateExperience")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateExperience(Models.experienciaModel em)
        {
            if (ModelState.IsValid)
            {
                if (Experiencesrv.CreateExperiences(em))
                    return RedirectToAction("getExperience");
                else
                    return View(em);
            }
            return View();


        }
    }
}