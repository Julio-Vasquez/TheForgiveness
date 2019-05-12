using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheForgiveness.Controllers
{
    public class DashBoardController : Controller
    {
        private Util.Util util = new Util.Util();
        // GET: Profile
        [HttpGet]
        public ActionResult Index()
        {
            if (util.testcontrol(Convert.ToString(Session["control"])))
            {
                Services.menuService menu = new Services.menuService();
                Services.rolService rol = new Services.rolService();

                Session["Role"] = rol.getRole(Session["username"].ToString());
                Session["dinMenu"] = menu.getMenu(Session["username"].ToString());

                System.Data.DataTable dt = Session["dinMenu"] as System.Data.DataTable;
                if (dt.Rows.Count >0)
                {
                    return View();
                }
                return RedirectToAction("NoFound", "Shared");   
            }
            else
            {
                return RedirectToAction("Error404", "Shared");
            }
        } 
    }
}