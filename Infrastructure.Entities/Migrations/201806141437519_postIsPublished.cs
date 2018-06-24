namespace Infrastructure.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postIsPublished : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "IsPublished", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "IsPublished");
        }
    }
}
