using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Infrastructure
{
    public class PortalExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var urlHelper = new UrlHelper(filterContext.RequestContext);
            filterContext.Result = new RedirectResult(
                urlHelper.Action("Error", "Common", new { msg = filterContext.Exception.Message })
            );

            filterContext.ExceptionHandled = true;
        }
    }
}