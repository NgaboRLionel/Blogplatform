namespace BlogPl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "images", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "images");
        }
    }
}
