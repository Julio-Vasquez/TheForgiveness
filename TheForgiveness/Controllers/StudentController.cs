using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class StudentController : Controller
    {
        private Services.StudentService es = new Services.StudentService();
        private Services.DepartmentService ds = new Services.DepartmentService();
        private Services.MunicipalityService ms = new Services.MunicipalityService();
        private Services.GenderService gene = new Services.GenderService();
        private Services.grupoService grup = new Services.grupoService();
        #region HTTPMethod Get

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateStudent")]
        public PartialViewResult CreateStudent()
        {
            ViewData["departamentos"] = JsonConvert.SerializeObject(ds.queryDepartamento());
            ViewData["municipios"] = JsonConvert.SerializeObject(ms.queryMunicipio());
            ViewData["generos"] = JsonConvert.SerializeObject(gene.queryGenero());
            ViewData["grupos"] = JsonConvert.SerializeObject(grup.Groupsdt(int.Parse(Session["idAccount"].ToString())));
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateStudent")]
        public ActionResult UpdateStudent(int? id)
        {          
            if (id != null)
            {
                ViewData["departamentos"] = JsonConvert.SerializeObject(ds.queryDepartamento());
                ViewData["municipios"] = JsonConvert.SerializeObject(ms.queryMunicipio());
                ViewData["generos"] = JsonConvert.SerializeObject(gene.queryGenero());
                return View(es.SpecifyStudent(id));
            }
            return RedirectToAction("GetStudents");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetStudents")]
        public PartialViewResult GetStudents()
        {
            ViewBag.rol = Session["Role"].ToString();
            var res = es.listStudent(Session["Role"].ToString(),int.Parse(Session["idAccount"].ToString()));
            return PartialView(res);
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteStudent")]
        public ActionResult DeleteStudent(int? id)
        {
            if (id != null)
            {
                return View(es.SpecifyStudent(id));
            }
            return RedirectToAction("GetStudents");
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetStudents")]
        public ActionResult SpecifyStudent(int? id)
        {
            if (id != null)
            { 
                return View(es.SpecifyStudent(id));
            }
            return Redirect("GetStudents");
        }

        #endregion

        #region httpPOst
        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "CreateStudent")]
        public ActionResult CreateStudent(Models.StudentModel sm) 
        {
            ViewData["departamentos"] = JsonConvert.SerializeObject(ds.queryDepartamento());
            ViewData["municipios"] = JsonConvert.SerializeObject(ms.queryMunicipio());
            ViewData["generos"] = JsonConvert.SerializeObject(gene.queryGenero());
            ViewData["grupos"] = JsonConvert.SerializeObject(grup.Groupsdt(int.Parse(Session["idAccount"].ToString())));
            if (ModelState.IsValid)
            {
                if(es.CreateStudent(sm))
                    RedirectToAction("GetStudents");
                else
                    return View(sm);
            }
            return View(sm);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateStudent")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateVictimology(Models.StudentModel sm)
        {
            ViewData["departamentos"] = JsonConvert.SerializeObject(ds.queryDepartamento());
            ViewData["municipios"] = JsonConvert.SerializeObject(ms.queryMunicipio());
            ViewData["generos"] = JsonConvert.SerializeObject(gene.queryGenero());
            if (ModelState.IsValid)
            {
                if (es.UpdateStudent(sm))
                    return RedirectToAction("GetStudents");
                else
                    return View(sm);
            }
            return View(sm);
        }

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteStudent")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVictimology(int id)
        {
            if (es.DeleteStudent(id))
            {
                return RedirectToAction("GetStudents");
            }
            else
            {
                return View(es.SpecifyStudent(id));
            }

        }
        #endregion 
    }
}