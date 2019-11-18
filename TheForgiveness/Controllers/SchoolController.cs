using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class SchoolController : Controller
    {
        private Services.colegioService schoolsrv = new Services.colegioService();
        private Services.departamentoService ds = new Services.departamentoService();
        private Services.municipioService ms = new Services.municipioService();

        // GET: Schools
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateSchool")]
        public PartialViewResult CreateSchool()
        {
            ViewBag.departamento = ds.queryDepartamento();
            ViewBag.municipio = ms.queryMunicipio();
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetSchools")]
        public PartialViewResult GetSchools()
        {
            ViewBag.rol = Session["Role"].ToString();
            return PartialView(schoolsrv.listSchools());
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteSchool")]
        public PartialViewResult DeleteSchool()
        {
            
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateSchool")]
        public PartialViewResult UpdateSchool()
        {
            return PartialView();
        }

     

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetSchools")]
        public ActionResult SpecifySchool()
        {
            return View();
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateSchool")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSchools(Models.colegioModel school)
        {
            if (ModelState.IsValid)
            {
                if (schoolsrv.createSchool(school))
                {
                    return RedirectToAction("Index", "DashBoard");
                }
                ViewBag.departamento = ds.queryDepartamento();
                ViewBag.municipio = ms.queryMunicipio();
                return View(school);
            }
            return View(school);
        }
    }
}