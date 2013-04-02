using System.Web.Mvc;
using System.Web.Routing;
using RoRoWo.Blog.IoC;

namespace RoRoWo.Blog.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Blog_default",
                "{controller}/{action}/pi_{pageIndex}/ps_{pageSize}",
                new { controller = "Blog", action = "Index", pageIndex = 1, pageSize = 10 }
            );

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Blog", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );

        }

        protected void Application_Start()
        {
            //初始化IoC
            IoCHelper.InitializeWith(new DependencyResolverFactory());

            //注册自定义的控制器，使MVC控制器可以支持依赖注入
            ControllerBuilder.Current.SetControllerFactory(new ResolverControllerFactory().GetControllerFactory());
                        
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}