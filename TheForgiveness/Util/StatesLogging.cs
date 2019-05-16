using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TheForgiveness.Util
{
    public class StatesLogging : ActionFilterAttribute
    {
        private string State { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            State = Convert.ToString(filterContext.HttpContext.Session["control"]);

            if (!(State == "Login"))
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Shared",
                            action = "Error404"
                        }
                   )
                );
            }
        }
    }
}