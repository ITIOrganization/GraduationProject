namespace AlumniSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ff1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Graduates", "JobTitleId", "dbo.JobTitles");
            DropIndex("dbo.Graduates", new[] { "JobTitleId" });
            AlterColumn("dbo.Graduates", "JobTitleId", c => c.Int());
            CreateIndex("dbo.Graduates", "JobTitleId");
            AddForeignKey("dbo.Graduates", "JobTitleId", "dbo.JobTitles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Graduates", "JobTitleId", "dbo.JobTitles");
            DropIndex("dbo.Graduates", new[] { "JobTitleId" });
            AlterColumn("dbo.Graduates", "JobTitleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Graduates", "JobTitleId");
            AddForeignKey("dbo.Graduates", "JobTitleId", "dbo.JobTitles", "Id", cascadeDelete: true);
        }
    }
}
