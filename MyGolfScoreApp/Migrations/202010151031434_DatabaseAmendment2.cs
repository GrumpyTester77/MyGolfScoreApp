namespace MyGolfScoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseAmendment2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HoleViewModels", "CourseId", "dbo.CourseViewModels");
            DropIndex("dbo.HoleViewModels", new[] { "CourseId" });
            AlterColumn("dbo.HoleViewModels", "CourseId", c => c.Int());
            CreateIndex("dbo.HoleViewModels", "CourseId");
            AddForeignKey("dbo.HoleViewModels", "CourseId", "dbo.CourseViewModels", "CourseId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoleViewModels", "CourseId", "dbo.CourseViewModels");
            DropIndex("dbo.HoleViewModels", new[] { "CourseId" });
            AlterColumn("dbo.HoleViewModels", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.HoleViewModels", "CourseId");
            AddForeignKey("dbo.HoleViewModels", "CourseId", "dbo.CourseViewModels", "CourseId", cascadeDelete: true);
        }
    }
}
