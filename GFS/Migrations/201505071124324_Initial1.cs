namespace GFS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Forms", "FormType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Forms", "FormType");
        }
    }
}
