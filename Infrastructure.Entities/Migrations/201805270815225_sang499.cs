namespace Infrastructure.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sang499 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Commnets", newName: "Comments");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Comments", newName: "Commnets");
        }
    }
}
