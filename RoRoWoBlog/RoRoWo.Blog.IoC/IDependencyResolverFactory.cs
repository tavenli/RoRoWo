using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoRoWo.Blog.IoC
{
    public interface IDependencyResolverFactory
    {
        IDependencyResolver CreateInstance();
    }
}
