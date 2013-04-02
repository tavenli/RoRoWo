using System.Web.Mvc;

namespace RoRoWo.Blog.Web.Areas.MWeb
{
    public class MWebAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MWeb";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MWeb_FUpLoad",
                "MWeb/FUpLoad/{action}/{utype}",
                new { controller = "FUpLoad", action = "Index", utype = 0 }
            );

            context.MapRoute(
                "MWeb_default_pager",
                "MWeb/{controller}/{action}/pi_{pageIndex}/ps_{pageSize}",
                new { controller = "Login", action = "Index", pageIndex = 1, pageSize = 10 }
            );

            context.MapRoute(
                "MWeb_default",
                "MWeb/{controller}/{action}/{id}",
                new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
