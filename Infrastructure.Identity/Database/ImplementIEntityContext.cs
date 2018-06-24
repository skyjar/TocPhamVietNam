namespace Infrastructure.Identity.Database
{
    using Core.ApplicationServices.Database.Identity;

    public class ImplementIEntityContext : IIdentity
    {
        public object GetContext => new DefineIdentityContext();
    }
}
