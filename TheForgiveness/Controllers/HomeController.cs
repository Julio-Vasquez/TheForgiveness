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
        public ActionResult Login()
        {
            Session["username"] = "";
            Session["control"] = "Logout";
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.usuarioModel um)
        {

            if (us.login(um))
            {
                Session["username"] = um.UserName;
                Session["control"] = "Login";
                Session["idAccount"] = us.idcuenta(um.UserName);
                return RedirectToAction("Index", "DashBoard");
            }
            else
            {
                return View();
            }

        }


        public ActionResult SignUp()
        {
            ViewBag.genero = gs.queryGenero();
            ViewBag.documento = tds.queryTipoDocumento();
            ViewBag.departamento = ds.queryDepartamento();
            ViewBag.municipio = ms.queryMunicipio();
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Models.usuarioModel ums)
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
            else
            {
                ViewBag.genero = gs.queryGenero();
                ViewBag.documento = tds.queryTipoDocumento();
                ViewBag.departamento = ds.queryDepartamento();
                ViewBag.municipio = ms.queryMunicipio();
                return View();
            }

        }
    }
}