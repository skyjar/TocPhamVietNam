namespace Infrastructure.Entities.Config
{
    using System.Data.Entity.ModelConfiguration;
    using Core.ObjectModels.Entities;

    public class PostConfig : EntityTypeConfiguration<Post>
    {
        public PostConfig()
        {
            ToTable("Posts").HasKey(_ => _.Id);

            Property(_ => _.Title).IsMaxLength().IsUnicode().IsOptional();
            Property(_ => _.CoverPhoto).IsMaxLength().IsUnicode().IsOptional();
            Property(_ => _.Author).IsMaxLength().IsUnicode().IsOptional();
            Property(_ => _.CreatedOn).IsOptional();
            Property(_ => _.Body).HasColumnType("ntext").IsOptional();
            Property(_ => _.BodyHtml).HasColumnType("ntext").IsOptional();
            Property(_ => _.IsBanner).IsOptional();
            


            HasMany<Label>(_ => _.Labels)
            .WithMany(_ => _.Posts)
            .Map(_ =>
            {
                _.MapLeftKey("PostId");
                _.MapRightKey("LabelId");
                _.ToTable("LabelPost");
            });
        }
    }
}