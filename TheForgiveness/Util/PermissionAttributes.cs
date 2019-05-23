using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TheForgiveness.Services;
using TheForgiveness.Util;

namespace TheForgiveness.Util
{
    public class PermissionAttributes : ActionFilterAttribute
    {
        public string File { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (!Valid(this.File, filterContext.HttpContext.Session["dinMenu"] as System.Data.DataTable))
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Shared",
                            action = "BadRequest"
                        }
                    )
                );
            }
        }

        public bool Valid(string File, System.Data.DataTable permisos)
        {
            int cont = 0;
            foreach (System.Data.DataRow item in permisos.Rows)
            {
                if (Convert.ToString(item["Url_Vista"]) == File) 
                    cont++;
            }
            return cont > 0;
        }
    }

}