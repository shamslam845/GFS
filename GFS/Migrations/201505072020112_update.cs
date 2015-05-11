namespace GFS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FormContainers", "Description", c => c.String(maxLength: 50));
            AlterColumn("dbo.Forms", "Title", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Forms", "Title", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.FormContainers", "Description", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
