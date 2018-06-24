namespace Infrastructure.Identity.Config
{
    using System.Data.Entity.ModelConfiguration;
    using Infrastructure.Identity.Models;

    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            Property(_ => _.DateOfBirth).HasColumnType("date").IsOptional();
            Property(_ => _.FullName).IsMaxLength().IsUnicode().IsOptional();
            Property(_ => _.Address).IsMaxLength().IsUnicode().IsOptional();
        }
    }
}
