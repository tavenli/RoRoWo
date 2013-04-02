using System;
using System.Web.Mvc;

using System.Web;
using System.Web.Routing;
using System.Globalization;
using Microsoft.Practices.Unity;
using RoRoWo.Blog.IoC;

namespace RoRoWo.Blog.Common.IoCResolver.Unity
{

    /// <summary>
    /// 自定义的控制器，使MVC控制器可以支持依赖注入
    /// </summary>
    public class UnityControllerFactory : DefaultControllerFactory
    {
        private IDependencyResolver _Resolver;

        public UnityControllerFactory()
        {
            _Resolver = new UnityDependencyResolver();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controller = null;

            if (requestContext == null || controllerType == null)
            {
                try
                {
                    controller = base.GetControllerInstance(requestContext, controllerType);
                }
                catch (Exception ex) {  }
            }
            else
            {
                
                controller = _Resolver.Resolve<IController>(controllerType);
            }

            return controller;
        }
    }
}