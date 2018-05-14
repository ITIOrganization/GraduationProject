namespace AlumniSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "CompanyPhone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "CompanyPhone");
        }
    }
}
