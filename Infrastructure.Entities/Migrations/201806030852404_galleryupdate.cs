namespace Infrastructure.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class galleryupdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Images", newName: "Photos");
            AddColumn("dbo.Photos", "IsPhoto", c => c.Boolean());
            DropColumn("dbo.Photos", "IsImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "IsImage", c => c.Boolean());
            DropColumn("dbo.Photos", "IsPhoto");
            RenameTable(name: "dbo.Photos", newName: "Images");
        }
    }
}
