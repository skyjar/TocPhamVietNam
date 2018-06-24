namespace Infrastructure.Entities.Config
{
    using Core.ObjectModels.Entities;
    using System.Data.Entity.ModelConfiguration;

    public class CommentConfig : EntityTypeConfiguration<Comment>
    {
        public CommentConfig()
        {
            ToTable("Comments").HasKey(_ => _.Id);

            Property(_ => _.Author).IsMaxLength().IsUnicode().IsOptional();
            Property(_ => _.Content).IsMaxLength().IsUnicode().IsOptional();
            Property(_ => _.CreatedOn).IsOptional();

            HasRequired(_ => _.Post)
                .WithMany(_ => _.Comments)
                .HasForeignKey(_ => _.PostId)
                .WillCascadeOnDelete(true);
        }
    }
}