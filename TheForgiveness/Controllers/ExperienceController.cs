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
        private Services.ForgivenessService ConceptVictimsrv = new Services.ForgivenessService();
        private Services.PerceptionService percepservice = new Services.PerceptionService();
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


        // GET: Concept
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateConcepts")]
        public PartialViewResult CreateConcepts()
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
        public PartialViewResult ModalExperience()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetExperiences")]
        public ActionResult SpecifyExperiences(int? id)
        {
            ViewBag.rol = Session["Role"].ToString();
            

            return View(Experiencesrv.Exper(id));
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateExperience")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateExperience(Models.MyHistoryModel Mh)
        {
            try
            {

            
            if (ModelState.IsValid)
            {
                Models.ExperienceModel em = new Models.ExperienceModel();
                em.FechaExperiencia = Mh.TiempoExperiencia;
                em.Municipio = Mh.Municipio;
                em.Persona = int.Parse(Session["idAccount"].ToString());
                em.Experiencia = Mh.Experiencia;
                var res = Experiencesrv.CreateExperiences(em, int.Parse(Session["idAccount"].ToString()));
                if (res.Length > 0)
                {
                    ViewBag.departamento = ds.queryDepartamento();
                    ViewData["municipio"] = JsonConvert.SerializeObject(ms.queryMunicipio());
                    ViewBag.victimologia = res[0].Intent;
                    ViewBag.sugerencia = res[1].Intent;
                    return View("ModalExperience");
                }

                ViewBag.departamento = ds.queryDepartamento();
                ViewData["municipio"] = JsonConvert.SerializeObject(ms.queryMunicipio());
                return View(Mh);
            }
            return View();
            }
            catch (Exception ex)
            {
                return Redirect("~/Views/Shared/BadRequest.cshtml");
            }
        }
        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateConcepts")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateConcepts(Models.PerdonPosCoflicModel Mh)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    Models.ForgivenessModel fvm = new Models.ForgivenessModel();
                    fvm.ConceptoInicial = Mh.ConceptoInicial;
                    ConceptVictimsrv.CreateSubject(fvm, int.Parse(Session["idAccount"].ToString()));

                    Models.PerceptionModel cvm = new Models.PerceptionModel();
                    cvm.Descripcion = Mh.Descripcion;
                    var res = percepservice.CreateSubject(cvm, int.Parse(Session["idAccount"].ToString()));
                    if (res)
                    {
                        ViewBag.departamento = ds.queryDepartamento();
                        ViewData["municipio"] = JsonConvert.SerializeObject(ms.queryMunicipio());
                        return View("CreateExperience");
                    }

                    ViewBag.departamento = ds.queryDepartamento();
                    ViewData["municipio"] = JsonConvert.SerializeObject(ms.queryMunicipio());
                    return View(Mh);
                }
                return View();
            }
            catch (Exception ex)
            {
                return Redirect("~/Views/Shared/BadRequest.cshtml");
            }
        }
    }
}