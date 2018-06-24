namespace Infrastructure.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryPublish : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsPublished", c => c.Boolean());
            DropColumn("dbo.Posts", "IsPublished");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "IsPublished", c => c.Boolean());
            DropColumn("dbo.Categories", "IsPublished");
        }
    }
}
