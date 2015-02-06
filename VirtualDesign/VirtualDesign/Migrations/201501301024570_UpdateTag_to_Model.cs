namespace VirtualDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTag_to_Model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Models", "Tags", c => c.String(maxLength: 200));
            DropColumn("dbo.Models", "Tag");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "Tag", c => c.String());
            DropColumn("dbo.Models", "Tags");
        }
    }
}
