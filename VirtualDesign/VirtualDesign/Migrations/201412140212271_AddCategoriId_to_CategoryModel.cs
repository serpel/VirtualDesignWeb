namespace VirtualDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriId_to_CategoryModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Models", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Models", new[] { "Category_CategoryId" });
            RenameColumn(table: "dbo.Models", name: "Category_CategoryId", newName: "CategoryId");
            AlterColumn("dbo.Models", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Models", "CategoryId");
            AddForeignKey("dbo.Models", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Models", new[] { "CategoryId" });
            AlterColumn("dbo.Models", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Models", name: "CategoryId", newName: "Category_CategoryId");
            CreateIndex("dbo.Models", "Category_CategoryId");
            AddForeignKey("dbo.Models", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
