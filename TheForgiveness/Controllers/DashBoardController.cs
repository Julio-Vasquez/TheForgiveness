using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheForgiveness.Util;

namespace TheForgiveness.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: Profile
        [HttpGet]
        [StatesLogging]
        public ActionResult Index()
        {
            Services.MenuService menu = new Services.MenuService();
            Services.RoleService rol = new Services.RoleService();
            Services.DashBoardService dbs = new Services.DashBoardService();
            Session["Role"] = rol.getRole(Session["username"].ToString());
            Session["dinMenu"] = menu.getMenu(Session["username"].ToString());
            System.Data.DataTable dt = Session["dinMenu"] as System.Data.DataTable;
            if (dt.Rows.Count > 0)
            {
                ViewBag.cantidadestudiantes = dbs.CantStudent(3);
                ViewBag.cantidaddocentes = dbs.CantStudent(2);
                ViewBag.victimologias = dbs.CantVitimology();
                return View();
            }
            else
            {
                return RedirectToAction("NoFound", "Shared");
            }
        }
    }
}