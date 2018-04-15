using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RFS.Filters
{
    public class CheckLoginAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["UserName"] == null)
                return false;
            else
                return true;

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
           filterContext.Result = new RedirectResult("~/Account/Login");
        }
    }
}