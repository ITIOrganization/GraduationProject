namespace AlumniSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Fname", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Lname", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "Lname");
            DropColumn("dbo.AspNetUsers", "Fname");
        }
    }
}
