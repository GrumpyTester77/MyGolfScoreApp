namespace MyGolfScoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseViewModels",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        HoleNumber = c.Int(nullable: false),
                        Par = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        StrokeIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.RoundViewModels",
                c => new
                    {
                        RoundId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(),
                        HoleScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoundId)
                .ForeignKey("dbo.CourseViewModels", t => t.CourseId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoundViewModels", "CourseId", "dbo.CourseViewModels");
            DropIndex("dbo.RoundViewModels", new[] { "CourseId" });
            DropTable("dbo.RoundViewModels");
            DropTable("dbo.CourseViewModels");
        }
    }
}
