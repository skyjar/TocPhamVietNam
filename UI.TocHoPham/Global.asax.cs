namespace UI.TocHoPham
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Reflection;
    using System.Collections.Generic;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Common.WebHost;
    using DependencyResolver.Modules;

    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private IKernel _kernel;

        protected override IKernel CreateKernel()
        {
            if (_kernel == null)
            {
                _kernel = new StandardKernel();
                _kernel.Load(Assembly.GetExecutingAssembly());
                _kernel.Load(new List<NinjectModule>() {
                    new InfrastructureModules(),
                    new ServiceModules()
                });
            }

            return _kernel;
        }
    }
}