namespace Infrastructure.Entities.Config
{
    using System.Data.Entity.ModelConfiguration;
    using Core.ObjectModels.Entities;

    public class CategoryConfig : EntityTypeConfiguration<Category>
    {
        public CategoryConfig()
        {
            ToTable("Categories").HasKey(_ => _.Id);

            Ignore(_ => _.HasParent);
            Ignore(_ => _.HaveChildrens);

            Property(_ => _.Name).IsMaxLength().IsUnicode().IsOptional();
            Property(_ => _.CategoryPath).IsMaxLength().IsUnicode().IsOptional();
            Property(_ => _.IsPublished).IsOptional();

            HasOptional(_ => _.Parent)
                .WithMany(_ => _.Childrens)
                .HasForeignKey<int?>(_ => _.ParentId)
                .WillCascadeOnDelete(false);
            HasMany(_ => _.Posts)
                .WithMany(_ => _.Categories)
                .Map(_ =>
                {
                    _.MapLeftKey("CategoryId");
                    _.MapRightKey("PostId");
                    _.ToTable("PostCategory");
                });
        }
    }
}