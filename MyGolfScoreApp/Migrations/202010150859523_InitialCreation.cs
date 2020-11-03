namespace MyGolfScoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseViewModels",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        HoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.HoleViewModels", t => t.HoleId, cascadeDelete: true)
                .Index(t => t.HoleId);
            
            CreateTable(
                "dbo.HoleViewModels",
                c => new
                    {
                        HoleId = c.Int(nullable: false, identity: true),
                        HoleNumber = c.Int(nullable: false),
                        Par = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        StrokeIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HoleId);
            
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
            DropForeignKey("dbo.CourseViewModels", "HoleId", "dbo.HoleViewModels");
            DropIndex("dbo.RoundViewModels", new[] { "CourseId" });
            DropIndex("dbo.CourseViewModels", new[] { "HoleId" });
            DropTable("dbo.RoundViewModels");
            DropTable("dbo.HoleViewModels");
            DropTable("dbo.CourseViewModels");
        }
    }
}
