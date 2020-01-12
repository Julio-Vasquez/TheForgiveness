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
        private Services.UserService us = new Services.UserService();
        private Services.GenderService gs = new Services.GenderService();
        private Services.TypeDocService tds = new Services.TypeDocService();
        private Services.DepartmentService ds = new Services.DepartmentService();
        private Services.MunicipalityService ms = new Services.MunicipalityService();

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
                Session["idAccount"] = us.idAccount(um.Username);
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

            string res = Request.Form.ToString();
            Console.WriteLine(res);
            Models.PeopleModel pm = new Models.PeopleModel
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

            bool test = us.signup(ums, pm, long.Parse(Request.Form["Telefono"]), Request.Form["email"]);
            if (test) 
            {
                return RedirectToAction("Login");
            }
            ViewBag.genero = gs.queryGenero();
            ViewBag.documento = tds.queryTipoDocumento();
            ViewBag.departamento = ds.queryDepartamento();
            ViewData["municipio"] = JsonConvert.SerializeObject(ms.queryMunicipio());
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
            else
            {
                ViewBag.Class = "text-danger";
                ViewBag.Records = "Name : " + Request.Form["userName"].ToString() + "SubNormal de mierda, no existe eso!!!!!!";
            }
            return PartialView("ResetPassword");
        }
    }
}