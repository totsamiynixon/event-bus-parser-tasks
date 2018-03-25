
using BLL.Implementations;
using BLL.Interfaces;
using DAL.Data;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using TinyMessenger;

namespace IFL.DI
{
    public class NinjectDependencyResolver :
        System.Web.Mvc.IDependencyResolver,
        System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings(_kernel);
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(this._kernel.BeginBlock());
        }

        public static void AddBindings(IKernel kernel)
        {
            kernel.Bind<ApplicationDbContext>().To<ApplicationDbContext>();
            kernel.Bind<ITagsCounterTaskService>().To<TagsCounterTaskService>().InRequestScope();
            kernel.Bind<ITinyMessengerHub>().To<TinyMessengerHub>().InSingletonScope();
        }

        public static T GetService<T>() where T : class
        {
            return DependencyResolver.Current?.GetService<T>() ?? (T)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(T));
        }

        public void Dispose()
        {

        }
    }
}
