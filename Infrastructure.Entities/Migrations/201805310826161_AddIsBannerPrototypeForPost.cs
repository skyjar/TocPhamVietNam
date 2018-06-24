namespace Infrastructure.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsBannerPrototypeForPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "IsBanner", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "IsBanner");
        }
    }
}
