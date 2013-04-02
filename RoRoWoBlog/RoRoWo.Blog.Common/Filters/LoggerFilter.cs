using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc;

namespace RoRoWo.Blog.Common.Filters
{
    /// <summary>
    /// 记录日志
    /// </summary>
    public class LoggerFilter : FilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewData["ExecutingLogger"] = "写入日志！时间：" + DateTime.Now;
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewData["ExecutedLogger"] = "写入日志！时间：" + DateTime.Now;
        }

    }
}
