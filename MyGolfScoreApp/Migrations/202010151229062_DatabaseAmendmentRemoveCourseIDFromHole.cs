namespace MyGolfScoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseAmendmentRemoveCourseIDFromHole : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HoleViewModels", "CourseId", "dbo.CourseViewModels");
            DropIndex("dbo.HoleViewModels", new[] { "CourseId" });
            DropColumn("dbo.HoleViewModels", "CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HoleViewModels", "CourseId", c => c.Int());
            CreateIndex("dbo.HoleViewModels", "CourseId");
            AddForeignKey("dbo.HoleViewModels", "CourseId", "dbo.CourseViewModels", "CourseId");
        }
    }
}
