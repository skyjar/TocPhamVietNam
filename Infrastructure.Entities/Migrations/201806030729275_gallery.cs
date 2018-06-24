namespace Infrastructure.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gallery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gallery",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedOn = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        IsBackground = c.Boolean(),
                        IsImage = c.Boolean(),
                        GalleryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gallery", t => t.GalleryId, cascadeDelete: true)
                .Index(t => t.GalleryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "GalleryId", "dbo.Gallery");
            DropIndex("dbo.Images", new[] { "GalleryId" });
            DropTable("dbo.Images");
            DropTable("dbo.Gallery");
        }
    }
}
