namespace VirtualDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CatergoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CatergoryId);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 200),
                        CategoryId = c.Int(nullable: false),
                        PictureFile = c.Binary(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Category_CatergoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ModelId)
                .ForeignKey("dbo.Categories", t => t.Category_CatergoryId)
                .Index(t => t.Category_CatergoryId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "Category_CatergoryId", "dbo.Categories");
            DropIndex("dbo.Tags", new[] { "ModelId" });
            DropIndex("dbo.Models", new[] { "Category_CatergoryId" });
            DropTable("dbo.Tags");
            DropTable("dbo.Models");
            DropTable("dbo.Categories");
        }
    }
}
