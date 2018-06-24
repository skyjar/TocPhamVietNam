namespace Infrastructure.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5_23_2018_phase1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(),
                        CategoryPath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(storeType: "ntext"),
                        BodyHtml = c.String(storeType: "ntext"),
                        Author = c.String(),
                        CreatedOn = c.DateTimeOffset(precision: 7),
                        CoverPhoto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Commnets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Content = c.String(),
                        CreatedOn = c.DateTimeOffset(precision: 7),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Labels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LabelPost",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        LabelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.LabelId })
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Labels", t => t.LabelId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.LabelId);
            
            CreateTable(
                "dbo.PostCategory",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.PostId })
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostCategory", "PostId", "dbo.Posts");
            DropForeignKey("dbo.PostCategory", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.LabelPost", "LabelId", "dbo.Labels");
            DropForeignKey("dbo.LabelPost", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Commnets", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Categories", "ParentId", "dbo.Categories");
            DropIndex("dbo.PostCategory", new[] { "PostId" });
            DropIndex("dbo.PostCategory", new[] { "CategoryId" });
            DropIndex("dbo.LabelPost", new[] { "LabelId" });
            DropIndex("dbo.LabelPost", new[] { "PostId" });
            DropIndex("dbo.Commnets", new[] { "PostId" });
            DropIndex("dbo.Categories", new[] { "ParentId" });
            DropTable("dbo.PostCategory");
            DropTable("dbo.LabelPost");
            DropTable("dbo.Labels");
            DropTable("dbo.Commnets");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
