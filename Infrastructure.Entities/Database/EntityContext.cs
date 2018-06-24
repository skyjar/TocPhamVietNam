namespace Infrastructure.Entities.Database
{
    using Core.ApplicationServices.Database.Entitty;

    public class EntityContext : IEntity
    {
        public object GetContext => new TocHoPhamContext();
    }
}