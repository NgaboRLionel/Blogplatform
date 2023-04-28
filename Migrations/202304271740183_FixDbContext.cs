namespace BlogPl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDbContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "created_by", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "created_by");
        }
    }
}
