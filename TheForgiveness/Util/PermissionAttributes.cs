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
            PermissionAttributesService pas = new PermissionAttributesService();
            base.OnActionExecuting(filterContext);
            string Role = Convert.ToString(filterContext.HttpContext.Session["Role"]);
            if (!pas.Valid_Permission(Role, this.File))
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
    }

}