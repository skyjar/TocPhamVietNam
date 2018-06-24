namespace Infrastructure.Entities.Config
{
    using Core.ObjectModels.Entities;
    using System.Data.Entity.ModelConfiguration;

    public class PhotoConfig : EntityTypeConfiguration<Photo>
    {
        public PhotoConfig()
        {
            ToTable("Photos").HasKey(_ => _.Id);

            Property(_ => _.IsBackground).IsOptional();
            Property(_ => _.IsPhoto).IsOptional();
            Property(_ => _.Alternative).IsMaxLength().IsUnicode().IsOptional();
            Property(_ => _.Url).IsMaxLength().IsUnicode().IsOptional();
        }
    }
}
