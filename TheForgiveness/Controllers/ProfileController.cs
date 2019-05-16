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
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "Profile")]
        public ActionResult Profile()
        {

            Services.perfilServices ps = new Services.perfilServices();
            var res = ps.myData(Convert.ToString(Session["username"]));
            return View(
                    new Models.PerfilModel(
                            long.Parse(res["Identificación"].ToString()),
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
        public ActionResult UpdateUser()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        public ActionResult UpdatePerfil()
        {
            return View();
        }

        [HttpGet]
        [StatesLogging]
        public ActionResult User()
        {
            return View();
        }

        #region POSTMethod
        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "ChangePassword")]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(Models.PasswordModel pm)
        {
            if (ModelState.IsValid && us.ResetPassWordUser(pm, Session["username"].ToString()))
                return RedirectToAction("Profile");
            return View();
        }

        #endregion POSTMethod

    }
}