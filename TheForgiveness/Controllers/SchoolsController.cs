using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class SchoolsController : Controller
    {
        private Util.Util util = new Util.Util();
        private Services.colegioService schoolsrv = new Services.colegioService();
        private Services.departamentoService ds = new Services.departamentoService();
        private Services.municipioService ms = new Services.municipioService();
        // GET: Schools
        [HttpGet]
        public ActionResult CreateSchools()
        {
            ViewBag.departamento = ds.queryDepartamento();
            ViewBag.municipio = ms.queryMunicipio();
            return View();
        }
        public ActionResult Getschools()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
                return View(schoolsrv.listSchools());
            return RedirectToAction("Error404", "Shared");
        }

        [HttpPost]
        public ActionResult CreateSchools(Models.colegioModel school) {
            if (schoolsrv.createSchool(school))
            {
                return RedirectToAction("Index", "DashBoard");
            }
            else
            {
                ViewBag.departamento = ds.queryDepartamento();
                ViewBag.municipio = ms.queryMunicipio();
                return View(school);
            }
        }
    }
}