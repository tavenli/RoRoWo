using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc;

namespace RoRoWo.Blog.Common.Filters
{
    /// <summary>
    /// 异常捕获
    /// </summary>
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext filterContext)
        {
            filterContext.Controller.ViewData["ErrorMessage"] = filterContext.Exception.Message;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Exception",
                ViewData = filterContext.Controller.ViewData,
            };

            //告诉系统，异常已经处理，不要再次处理了
            filterContext.ExceptionHandled = true;
        }

    }

}
