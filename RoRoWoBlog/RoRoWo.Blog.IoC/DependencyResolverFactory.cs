using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;

namespace RoRoWo.Blog.IoC
{
    public class DependencyResolverFactory : IDependencyResolverFactory
    {
        private readonly Type _resolverType;

        public DependencyResolverFactory()
            : this(ConfigurationManager.AppSettings["dependencyResolverTypeName"])
        {
        }

        public DependencyResolverFactory(string resolverTypeName)
        {
            _resolverType = Type.GetType(resolverTypeName, true, true);
        }

        public IDependencyResolver CreateInstance()
        {
            return Activator.CreateInstance(_resolverType) as IDependencyResolver;
        }
    }
}
