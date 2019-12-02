using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;
using Newtonsoft.Json;

namespace TheForgiveness.Controllers
{
    public class ProfileController : Controller
    {
        
        private Services.usuarioService us = new Services.usuarioService();
        private Services.perfilServices ps = new Services.perfilServices();
        private Services.departamentoService ds = new Services.departamentoService();
        private Services.municipioService ms = new Services.municipioService();
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
            ViewData["municipio"] = res["mun"].ToString();
            ViewData["documento"] = res["tipdoc"].ToString();
            ViewData["genero"] = res["gen"].ToString();
            return PartialView(
                    new Models.PerfilModel(
                            int.Parse(res["Edad"].ToString()),
                            long.Parse(res["Identificacion"].ToString()),
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
            ViewData["municipio"] = res["mun"].ToString();
            ViewData["documento"] = res["tipdoc"].ToString();
            ViewData["genero"] = res["gen"].ToString();
            ViewData["departamento"] = res["Departamento"].ToString();
            ViewData["departamentos"] = JsonConvert.SerializeObject(ds.queryDepartamento());
            ViewData["municipios"] = JsonConvert.SerializeObject(ms.queryMunicipio());


            return View(new Models.PerfilModel(
                            long.Parse(res["Identificacion"].ToString()),
                            res["Primer_Nombre"].ToString(),
                            res["Segundo_Nombre"].ToString(),
                            res["Primer_Apellido"].ToString(),
                            res["Segundo_Apellido"].ToString(),
                            DateTime.Parse(res["FechaDeNacimeinto"].ToString()).ToString("yyyy-MM-dd"),
                            int.Parse(res["Edad"].ToString()),
                            int.Parse(res["gen"].ToString()),
                            int.Parse(res["tipdoc"].ToString()),
                            int.Parse(res["mun"].ToString())

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

        [HttpPost]
        [StatesLogging]
        [PermissionAttributes(File = "UpdatePerfil")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePerfil(Models.PerfilModel pm)
        {
            if (ModelState.IsValid && ps.updateprofile(pm))
                return RedirectToAction("Profile");
            return View();
        }

        #endregion POSTMethod

    }
}