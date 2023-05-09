namespace BlogPl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagesUrlToBlog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "imagesUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "imagesUrl");
        }
    }
}
