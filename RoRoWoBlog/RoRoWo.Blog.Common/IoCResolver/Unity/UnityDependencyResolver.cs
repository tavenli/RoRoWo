using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Configuration;
using System.Collections.ObjectModel;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using RoRoWo.Blog.IoC;
using RoRoWo.Blog.Utility;

namespace RoRoWo.Blog.Common.IoCResolver.Unity
{
    public class UnityDependencyResolver : DisposableResource, IDependencyResolver
    {
        #region Disposable
        
        [DebuggerStepThrough]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _container.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion

        private readonly IUnityContainer _container;    

        /// <summary>
        /// 内部构造方法
        /// </summary>
        [DebuggerStepThrough]
        public UnityDependencyResolver()
        {
            _container = new UnityContainerBuilder().BuilderUnityContainer();

            //手动 注册缓存模块
            //UnityContext.Current.Container.RegisterInstance<ICacheStrategy>(new WebCaching());
        }
                
        [DebuggerStepThrough]
        public void Register<T>(T instance)
        {

            _container.RegisterInstance(instance);
        }

        [DebuggerStepThrough]
        public void Inject<T>(T existing)
        {

            _container.BuildUp(existing);
        }

        [DebuggerStepThrough]
        public T Resolve<T>(Type type)
        {

            return (T)_container.Resolve(type);
        }

        [DebuggerStepThrough]
        public T Resolve<T>(Type type, string name)
        {

            return (T)_container.Resolve(type, name);
        }

        [DebuggerStepThrough]
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        [DebuggerStepThrough]
        public T Resolve<T>(string name)
        {

            return _container.Resolve<T>(name);
        }

        [DebuggerStepThrough]
        public IEnumerable<T> ResolveAll<T>()
        {
            IEnumerable<T> namedInstances = _container.ResolveAll<T>();
            T unnamedInstance = default(T);

            try
            {
                unnamedInstance = _container.Resolve<T>();
            }
            catch (ResolutionFailedException)
            {
                //When default instance is missing
            }

            if (Equals(unnamedInstance, default(T)))
            {
                return namedInstances;
            }

            return new ReadOnlyCollection<T>(new List<T>(namedInstances) { unnamedInstance });
        }

      

    }
}
