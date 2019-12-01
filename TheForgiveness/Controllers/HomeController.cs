using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class HomeController : Controller
    {
        private Services.usuarioService us = new Services.usuarioService();
        private Services.generoService gs = new Services.generoService();
        private Services.tipoDocumentoService tds = new Services.tipoDocumentoService();
        private Services.departamentoService ds = new Services.departamentoService();
        private Services.municipioService ms = new Services.municipioService();

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Login()
        {
            Session["username"] = "";
            Session["control"] = "Logout";
            Session["Role"] = "";
            Session["idAccount"] = 0;
            Session["dinMenu"] = new System.Data.DataTable();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.UsuarioModel um)
        {
            if (us.login(um))
            {
                Session["username"] = um.Username;
                Session["control"] = "Login";
                Session["idAccount"] = us.idcuenta(um.Username);
                return RedirectToAction("Index", "DashBoard");
            }
                return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult SignUp()
        {
            ViewBag.genero = gs.queryGenero();
            ViewBag.documento = tds.queryTipoDocumento();
            ViewBag.departamento = ds.queryDepartamento();
            ViewData["municipio"] = JsonConvert.SerializeObject(ms.queryMunicipio());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Models.UsuarioModel ums)
        {
            Models.personaModel pm = new Models.personaModel
                (
                    long.Parse(Request.Form["NumIdentificacion"]),
                    Request.Form["PriNombre"],
                    Request.Form["SegNombre"],
                    Request.Form["PriApellido"],
                    Request.Form["SegApellido"],
                    Request.Form["FechaNacimiento"],
                    int.Parse(Request.Form["Genero"]),
                    int.Parse(Request.Form["Identificacion"]),
                    int.Parse(Request.Form["Municipio"])
                );
            if (us.signup(ums, pm, long.Parse(Request.Form["Telefono"]), Request.Form["email"]))
            {
                return RedirectToAction("Login");
            }
                ViewBag.genero = gs.queryGenero();
                ViewBag.documento = tds.queryTipoDocumento();
                ViewBag.departamento = ds.queryDepartamento();
                ViewBag.municipio = ms.queryMunicipio();
                return View();
        }

        [HttpGet]
        public PartialViewResult ResetPassword()
        {
            return PartialView();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ResetPassword(string un)
        {

            if (us.ExistUser(Request.Form["userName"].ToString()))
            {
                Util.Email email = new Util.Email();
                email.SendMail(Request.Form["userName"].ToString(), Request.Form["numIdentificacion"].ToString());
                ViewBag.Class = "text-success";
                ViewBag.Records = "Name : " + Request.Form["userName"].ToString() + " Usuario Existente!!!!";
            }
            else {
                ViewBag.Class = "text-danger";
                ViewBag.Records = "Name : " + Request.Form["userName"].ToString() + "SubNormal de mierda, no existe eso!!!!!!";
            }
            return PartialView("ResetPassword");
        }
    }
}