namespace MyGolfScoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseAmendment1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HoleViewModels",
                c => new
                    {
                        HoleId = c.Int(nullable: false, identity: true),
                        HoleNumber = c.Int(nullable: false),
                        Par = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        StrokeIndex = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HoleId)
                .ForeignKey("dbo.CourseViewModels", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoleViewModels", "CourseId", "dbo.CourseViewModels");
            DropIndex("dbo.HoleViewModels", new[] { "CourseId" });
            DropTable("dbo.HoleViewModels");
        }
    }
}
