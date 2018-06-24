namespace Infrastructure.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photoAlt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "Alternative", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photos", "Alternative");
        }
    }
}
