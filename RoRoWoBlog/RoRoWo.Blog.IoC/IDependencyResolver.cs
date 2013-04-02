using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoRoWo.Blog.IoC
{
    public interface IDependencyResolver : IDisposable
    {
        void Register<T>(T instance);

        void Inject<T>(T existing);

        T Resolve<T>(Type type);

        T Resolve<T>(Type type, string name);

        T Resolve<T>();

        T Resolve<T>(string name);

        IEnumerable<T> ResolveAll<T>();
    }

}
