using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class ProfileController : Controller
    {
        private Util.Util util = new Util.Util();
        private Services.usuarioService us = new Services.usuarioService();
        // GET: Profile
        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "ChangePassword")]
        public PartialViewResult ChangePassword()
        {
            return PartialView();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "Profile")]
        public PartialViewResult Profile()
        {
            Services.perfilServices ps = new Services.perfilServices();
            var res = ps.myData(Convert.ToString(Session["username"]));
            return PartialView(
                    new Models.PerfilModel(
                            long.Parse(res["Identificacion"].ToString()),
                            res["Primer_Nombre"].ToString(),
                            res["Segundo_Nombre"].ToString(),
                            res["Primer_Apellido"].ToString(),
                            res["Segundo_Apellido"].ToString(),
                            res["FechaDeNacimeinto"].ToString(),
                            int.Parse(res["Edad"].ToString()),
                            res["Genero"].ToString(),
                            res["Tipo_Documento"].ToString(),
                            res["Municipio"].ToString()
                        )
                );

        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdateUser")]
        public ActionResult UpdateUser()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdatePerfil")]
        public ActionResult UpdatePerfil()
        {
            Services.perfilServices ps = new Services.perfilServices();
            var res = ps.myData(Convert.ToString(Session["username"]));
            var viewRes = new Models.PerfilModel(
                            long.Parse(res["Identificacion"].ToString()),
                            res["Primer_Nombre"].ToString(),
                            res["Segundo_Nombre"].ToString(),
                            res["Primer_Apellido"].ToString(),
                            res["Segundo_Apellido"].ToString(),
                            res["FechaDeNacimeinto"].ToString(),
                            int.Parse(res["Edad"].ToString()),
                            res["Genero"].ToString(),
                            res["Tipo_Documento"].ToString(),
                            res["Municipio"].ToString()
                        );
            return View(viewRes);
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "User")]
        public PartialViewResult User()
        {
            return PartialView();
        }

        #region POSTMethod
        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "ChangePassword")]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(Models.PasswordModel pm)
        {
            if (ModelState.IsValid && us.ChangePassword(pm, Session["username"].ToString()))
                return RedirectToAction("Profile");
            return View();
        }

        #endregion POSTMethod

    }
}