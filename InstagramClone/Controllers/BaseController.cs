using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dashing;
using InstagramClone.App_Start;

namespace InstagramClone.Controllers
{
    public class BaseController : Controller
    {
        protected ISession session;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var config = new DashingConfiguration();
            this.session = config.BeginSession();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
            {
                this.session.Complete();
            }

            this.session.Dispose();
        }
    }
}