namespace Infrastructure.Entities.Config
{
    using Core.ObjectModels.Entities;
    using System.Data.Entity.ModelConfiguration;

    public class AboutUsConfig : EntityTypeConfiguration<AboutUs>
    {
        public AboutUsConfig()
        {
            ToTable("AboutUs").HasKey(_ => _.Id);

            Property(_ => _.Title).IsMaxLength().IsUnicode().IsOptional();
            Property(_ => _.CoverPhoto).IsMaxLength().IsUnicode().IsOptional();
            Property(_ => _.BodyHtml).HasColumnType("ntext").IsOptional();
        }
    }
}
