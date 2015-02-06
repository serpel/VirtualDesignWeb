namespace VirtualDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikes_to_Model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Models", "Likes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Models", "Likes");
        }
    }
}
