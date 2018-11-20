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
            Services.generoService gs = new Services.generoService();
            Services.tipoDocumentoService tds = new Services.tipoDocumentoService();
            Services.departamentoService ds = new Services.departamentoService();
            Services.municipioService ms = new Services.municipioService();
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
                    int.Parse(Request.Form["NumIdentificacion"]),
                    Request.Form["PriNombre"],
                    Request.Form["SegNombre"],
                    Request.Form["PriApellido"],
                    Request.Form["SegApellido"],
                    Request.Form["FechaNacimiento"],
                    int.Parse(Request.Form["Genero"]),
                    Request.Form["Identificacion"],
                    int.Parse(Request.Form["Municipio"])
                );

            Models.usuarioModel um = new Models.usuarioModel
                (
                    Request.Form["username"],
                    Request.Form["password"],
                    Request.Form["confirmpassword"],
                    urldbProfile
                );
            if (us.signup(um,pm, int.Parse(Request.Form["NumIdentificacion"]), int.Parse(Request.Form["Genero"]), int.Parse(Request.Form["Telefono"]), Request.Form["email"],int.Parse(Request.Form["Municipio"]))) {
                return RedirectToAction("Login");
            }
            else {
                return View();
            }
            
        }
    }
}