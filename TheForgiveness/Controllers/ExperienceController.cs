using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class ExperienceController : Controller
    {
        private Services.ExperienceService Experiencesrv = new Services.ExperienceService();
        private Services.DepartmentService ds = new Services.DepartmentService();
        private Services.MunicipalityService ms = new Services.MunicipalityService();
       // GET: Concept
       [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateExperience")]
        public PartialViewResult CreateExperience()
        {
            ViewBag.departamento = ds.queryDepartamento();
            ViewData["municipio"] = JsonConvert.SerializeObject(ms.queryMunicipio());
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateExperience")]
        public ActionResult UpdateExperience(int? id)
        {
            return View();
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
            ViewBag.rol = Session["Role"].ToString();
            return PartialView(Experiencesrv.listExperiencess());
        }

        [HttpGet]
        [StatesLogging]
        public PartialViewResult ModalExperience() {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetExperiences")]
        public ActionResult SpecifyExperiences()
        {
            ViewBag.rol = Session["Role"].ToString();
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateExperience")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateExperience(Models.ExperienceModel em)
        {
            if (ModelState.IsValid)
            { 
                var res = Experiencesrv.CreateExperiences(em,int.Parse(Session["idAccount"].ToString()));
                if (res.Length > 0)
                {
                    ViewBag.victimologia = res[0].Intent;
                    ViewBag.sugerencia = res[1].Intent;
                    return View("ModalExperience");
                }
                else
                {
                    ViewBag.departamento = ds.queryDepartamento();
                    ViewData["municipio"] = JsonConvert.SerializeObject(ms.queryMunicipio());
                    return View(em);
                }
            }
            return View();


        }

        
    }
}