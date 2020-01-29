using Newtonsoft.Json;
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
        private Services.SchoolService schoolsrv = new Services.SchoolService();
        private Services.DepartmentService ds = new Services.DepartmentService();
        private Services.MunicipalityService ms = new Services.MunicipalityService();

        // GET: Schools
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateSchool")]
        public PartialViewResult CreateSchool()
        {
            ViewBag.departamento = ds.queryDepartamento();
            ViewData["municipio"] = JsonConvert.SerializeObject(ms.queryMunicipio());
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
        public ActionResult DeleteSchool(int? id)
        {
            if (id != null)
            {
                System.Data.DataRow dr = schoolsrv.queryshoolsView(id);
                Models.SchoolViewModel shoolmodel = new Models.SchoolViewModel(int.Parse(dr["ID"].ToString()), dr["Nombre"].ToString(), dr["Municipio"].ToString());
                return PartialView(shoolmodel);
            }
            return RedirectToAction("GetSchools");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateSchool")]
        public ActionResult UpdateSchool(int? id)
        {
            if (id != null)
            {
                ViewBag.departamento = ds.queryDepartamento();
                ViewData["municipio"] = JsonConvert.SerializeObject(ms.queryMunicipio());
                System.Data.DataRow dr = schoolsrv.queryshools(id);
                Models.SchoolModel shoolmodel = new Models.SchoolModel(int.Parse(dr["ID"].ToString()), dr["Nombre"].ToString(), int.Parse(dr["Municipio"].ToString()));
                return View(shoolmodel);
            }
            return RedirectToAction("GetSchools");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetSchools")]
        public ActionResult SpecifySchool(int? id)
        {
            if (id != null)
            {
                ViewBag.rol = Session["Role"].ToString();
                System.Data.DataRow dr = schoolsrv.queryshoolsView(id);
                Models.SchoolViewModel shoolmodel = new Models.SchoolViewModel(int.Parse(dr["ID"].ToString()), dr["Nombre"].ToString(),dr["Municipio"].ToString());
                return View(shoolmodel);
            }
            return RedirectToAction("Error404", "Shared");
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateSchool")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSchool(Models.SchoolModel school)
        {
            if (ModelState.IsValid)
            {
                if (schoolsrv.createSchool(school))
                {
                    return RedirectToAction("Index", "DashBoard");
                }
                ViewBag.departamento = ds.queryDepartamento();
                ViewData["municipio"] = JsonConvert.SerializeObject(ms.queryMunicipio());
                return View(school);
            }
            ViewBag.departamento = ds.queryDepartamento();
            ViewData["municipio"] = JsonConvert.SerializeObject(ms.queryMunicipio());
            return View(school);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateSchool")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSchool(Models.SchoolModel cm)
        {
            if (ModelState.IsValid)
            {
                if (schoolsrv.UpdateSchool(cm)) 
                {
                    return RedirectToAction("GetSchools");
                }
            }
            ViewBag.departamento = ds.queryDepartamento();
            ViewData["municipio"] = JsonConvert.SerializeObject(ms.queryMunicipio());
            System.Data.DataRow dr = schoolsrv.queryshools(cm.ID);
            Models.SchoolModel shoolmodel = new Models.SchoolModel(int.Parse(dr["ID"].ToString()), dr["Nombre"].ToString(), int.Parse(dr["Municipio"].ToString()));
            return View(shoolmodel);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteSchool")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSchool(int id)
        {
            if (schoolsrv.DeleteSchool(id)) 
            {
                return RedirectToAction("GetSchools");
            }
            System.Data.DataRow dr = schoolsrv.queryshoolsView(id);
            Models.SchoolViewModel shoolmodel = new Models.SchoolViewModel(int.Parse(dr["ID"].ToString()), dr["Nombre"].ToString(), dr["Municipio"].ToString());
            return View(shoolmodel);
        }
    }
}