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
        
        private Services.usuarioService us = new Services.usuarioService();
        private Services.perfilServices ps = new Services.perfilServices();
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
            var res = us.MyUser(Convert.ToString(Session["username"]));
            return View(
                    new Models.UsuarioModel(
                        int.Parse(res["ID"].ToString()),
                        res["UserName"].ToString(),
                        res["PassWord"].ToString()
                   )
                );
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "UpdatePerfil")]
        public ActionResult UpdatePerfil()
        {
            var res = ps.myData(Convert.ToString(Session["username"]));
            return View(new Models.PerfilModel(
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
                        ));
        }

        [HttpGet]
        [StatesLogging]
        [PermissionAttributes(File = "User")]
        public ActionResult User()
        { 
            var res = us.MyUser(Convert.ToString(Session["username"]));
            return View(
                    new Models.UsuarioModel(
                        int.Parse(res["ID"].ToString()),
                        res["UserName"].ToString(),
                        res["PassWord"].ToString()
                   )
                );
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