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
        private Services.usuarioService us = new Services.usuarioService();
        private Services.perfilServices ps = new Services.perfilServices();
        private Services.departamentoService ds = new Services.departamentoService();
        private Services.municipioService ms = new Services.municipioService();
        private Services.generoService gene = new Services.generoService();
        private Services.tipoDocumentoService tido = new Services.tipoDocumentoService();

        private Util.Util util = new Util.Util();
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
        public ActionResult UpdateStudent()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetStudents")]
        public PartialViewResult GetStudents()
        {

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
                );
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "DeleteStudent")]
        public ActionResult DeleteStudent()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "GetStudents")]
        public ActionResult SpecifyStudent()
        {
            return View();
        }

        #endregion
    }
}