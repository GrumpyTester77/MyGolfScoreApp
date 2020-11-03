namespace MyGolfScoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseAmendmentAddCourseIDFromHole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoleViewModels", "CourseId", c => c.Int());
            CreateIndex("dbo.HoleViewModels", "CourseId");
            AddForeignKey("dbo.HoleViewModels", "CourseId", "dbo.CourseViewModels", "CourseId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoleViewModels", "CourseId", "dbo.CourseViewModels");
            DropIndex("dbo.HoleViewModels", new[] { "CourseId" });
            DropColumn("dbo.HoleViewModels", "CourseId");
        }
    }
}
