namespace DependencyResolver.Modules
{
    using Ninject.Modules;
    using Core.ApplicationServices.Database.Entitty;
    using Core.ObjectServices.Repositories;
    using Infrastructure.Entities.Database;
    using Infrastructure.Entities.Repositories;
    using Core.ApplicationServices.Database.Identity;
    using Infrastructure.Identity.Database;

    public class InfrastructureModules : NinjectModule
    {
        public override void Load()
        {
            Bind<IEntity>().To<EntityContext>();
            Bind<IIdentity>().To<ImplementIEntityContext>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}