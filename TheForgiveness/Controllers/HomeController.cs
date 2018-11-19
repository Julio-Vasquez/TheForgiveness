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