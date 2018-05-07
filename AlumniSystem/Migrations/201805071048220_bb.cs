namespace AlumniSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Complains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        SendDate = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Complains", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Complains", new[] { "UserId" });
            DropTable("dbo.Complains");
        }
    }
}
