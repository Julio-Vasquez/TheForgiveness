using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            Session["username"] = "";
            Session["control"] = "Logout";
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.usuarioModel um)
        {
            Services.usuarioService us = new Services.usuarioService();
            if (us.login(um))
            {
                Session["username"] = um.UserName;
                Session["control"] = "Login";
                Session["idAccount"] = us.idcuenta(um.UserName);
                return RedirectToAction("Index", "Profile");
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
        public ActionResult SignUp(int i)
        {
            //logic
            return View();
        }
    }
}