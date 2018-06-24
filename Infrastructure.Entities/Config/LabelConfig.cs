namespace Infrastructure.Entities.Config
{
    using System.Data.Entity.ModelConfiguration;
    using Core.ObjectModels.Entities;

    public class LabelConfig : EntityTypeConfiguration<Label>
    {
        public LabelConfig()
        {
            ToTable("Labels").HasKey(_ => _.Id);

            Property(_ => _.Name).HasMaxLength(255).IsUnicode().IsOptional();
        }
    }
}