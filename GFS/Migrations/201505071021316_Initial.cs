namespace GFS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        EmailID = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(nullable: false, maxLength: 50),
                        SectionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmailID);
            
            CreateTable(
                "dbo.FeedbackContainers",
                c => new
                    {
                        FeedbackContainerID = c.Int(nullable: false, identity: true),
                        DateTimes = c.DateTime(nullable: false),
                        FormContainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FeedbackContainerID);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackID = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false, maxLength: 500),
                        UserID = c.String(nullable: false, maxLength: 128),
                        FeedbackContainerID = c.Int(nullable: false),
                        SectionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FeedbackID)
                .ForeignKey("dbo.FeedbackContainers", t => t.FeedbackContainerID, cascadeDelete: true)
                .Index(t => t.FeedbackContainerID);
            
            CreateTable(
                "dbo.FormContainers",
                c => new
                    {
                        FormContainerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 50),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FormContainerID);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        FormID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 40),
                        FormContainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FormID)
                .ForeignKey("dbo.FormContainers", t => t.FormContainerID, cascadeDelete: true)
                .Index(t => t.FormContainerID);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionID = c.Int(nullable: false, identity: true),
                        SectionNumber = c.Int(nullable: false),
                        CourseName = c.String(nullable: false, maxLength: 20),
                        UserID = c.String(nullable: false, maxLength: 128),
                        FormContainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SectionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Forms", "FormContainerID", "dbo.FormContainers");
            DropForeignKey("dbo.Feedbacks", "FeedbackContainerID", "dbo.FeedbackContainers");
            DropIndex("dbo.Forms", new[] { "FormContainerID" });
            DropIndex("dbo.Feedbacks", new[] { "FeedbackContainerID" });
            DropTable("dbo.Sections");
            DropTable("dbo.Forms");
            DropTable("dbo.FormContainers");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.FeedbackContainers");
            DropTable("dbo.Emails");
        }
    }
}
