using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class SchoolsController : Controller
    {
        private Services.colegioService schoolsrv = new Services.colegioService();
        private Services.departamentoService ds = new Services.departamentoService();
        private Services.municipioService ms = new Services.municipioService();
        // GET: Schools
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateSchools")]
        public ActionResult CreateSchools()
        {
            ViewBag.departamento = ds.queryDepartamento();
            ViewBag.municipio = ms.queryMunicipio();
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "Getschools")]
        public ActionResult Getschools()
        {
            return View(schoolsrv.listSchools());
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateSchools")]
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