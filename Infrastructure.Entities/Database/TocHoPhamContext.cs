namespace Infrastructure.Entities.Database
{
    using System.Data.Entity;
    using System.Reflection;
    using Core.ObjectModels.Entities;

    public class TocHoPhamContext : DbContext
    {
        public TocHoPhamContext() : base("TocHoPham") { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Label> Labels { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}