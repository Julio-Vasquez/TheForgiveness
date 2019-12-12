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
        private Services.estudianteService es = new Services.estudianteService();
     
        #region HTTPMethod Get

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "CreateStudent")]
        public PartialViewResult CreateStudent()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateStudent")]
        public ActionResult UpdateStudent(int? id)
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
        public PartialViewResult GetStudents()
        {
            
            
            /*
            ViewBag.rol = Session["Role"].ToString();
            var res = ps.studendata(Convert.ToString(Session["username"]));
            ViewData["municipio"] = res["Municipio"].ToString();
            ViewData["documento"] = res["Tipo_Documento"].ToString();
            ViewData["genero"] = res["Genero"].ToString();
            return PartialView(
                    new Models.studentModel(
                            int.Parse(res["Edad"].ToString()),
                            res["Identificacion"].ToString(),
                            res["Primer_Nombre"].ToString(),
                            res["Segundo_Nombre"].ToString(),
                            res["Primer_Apellido"].ToString(),
                            res["Segundo_Apellido"].ToString(),
                            res["FechaDeNacimeinto"].ToString(),
                            int.Parse(res["Edad"].ToString())
                        )
                );*/
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
        public ActionResult CreateStudent(Models.studentModel sm) 
        {
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
        public ActionResult UpdateVictimology(Models.studentModel sm)
        {
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