namespace Infrastructure.Entities.Config
{
    using Core.ObjectModels.Entities;
    using System.Data.Entity.ModelConfiguration;

    public class GalleryConfig : EntityTypeConfiguration<Gallery>
    {
        public GalleryConfig()
        {
            ToTable("Gallery").HasKey(_ => _.Id);

            Property(_ => _.CreatedOn).IsOptional();
            Property(_ => _.Description).IsMaxLength().IsUnicode().IsOptional();
            Property(_ => _.Name).IsMaxLength().IsUnicode().IsOptional();

            HasMany(_ => _.Photos).WithRequired(_ => _.Gallery).HasForeignKey(_ => _.GalleryId);

        }
    }
}
