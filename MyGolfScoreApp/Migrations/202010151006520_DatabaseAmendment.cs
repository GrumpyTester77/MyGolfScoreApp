namespace MyGolfScoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseAmendment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseViewModels", "HoleId", "dbo.HoleViewModels");
            DropIndex("dbo.CourseViewModels", new[] { "HoleId" });
            DropColumn("dbo.CourseViewModels", "HoleId");
            DropTable("dbo.HoleViewModels");
        }
        
        public override void Down()
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
                    })
                .PrimaryKey(t => t.HoleId);
            
            AddColumn("dbo.CourseViewModels", "HoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.CourseViewModels", "HoleId");
            AddForeignKey("dbo.CourseViewModels", "HoleId", "dbo.HoleViewModels", "HoleId", cascadeDelete: true);
        }
    }
}
