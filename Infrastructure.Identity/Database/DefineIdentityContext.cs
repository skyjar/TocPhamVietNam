namespace Infrastructure.Identity.Database
{
    using System.Data.Entity;
    using System.Reflection;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Infrastructure.Identity.Models;

    public class DefineIdentityContext : IdentityDbContext<User>
    {
        public DefineIdentityContext() : base("TocHoPham")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
