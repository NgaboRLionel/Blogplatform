namespace BlogPl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrlsToBlog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "imageUrls", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "imageUrls");
        }
    }
}
