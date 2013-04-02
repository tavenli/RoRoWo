using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc;
using System.Web;
using System.Globalization;
using RoRoWo.Blog.IoC;

namespace RoRoWo.Blog.IoC
{

    /// <summary>
    /// 自定义的控制器实例化工厂
    /// </summary>
    public class ResolverControllerFactory
    {

        public IControllerFactory GetControllerFactory()
        {

            return IoCHelper.Resolve<IControllerFactory>();

        }
    }
}
