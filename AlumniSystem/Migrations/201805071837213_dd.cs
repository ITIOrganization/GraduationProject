namespace AlumniSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Graduates",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        JobTitleId = c.Int(nullable: false),
                        CareerObjective = c.String(maxLength: 500),
                        TrackId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        QualificationsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.JobTitles", t => t.JobTitleId, cascadeDelete: true)
                .ForeignKey("dbo.Qualifications", t => t.QualificationsId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.JobTitleId)
                .Index(t => t.TrackId)
                .Index(t => t.BranchId)
                .Index(t => t.QualificationsId);
            
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Author = c.String(nullable: false),
                        ReferenceUrl = c.String(nullable: false),
                        CertificationNumber = c.Int(nullable: false),
                        GraduateId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Graduates", t => t.GraduateId)
                .Index(t => t.GraduateId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        GraduateId = c.String(maxLength: 128),
                        StaffId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Graduates", t => t.GraduateId)
                .ForeignKey("dbo.Staffs", t => t.StaffId)
                .Index(t => t.GraduateId)
                .Index(t => t.StaffId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TrackId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        JobTitleId = c.Int(nullable: false),
                        QualificationsId = c.Int(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.JobTitles", t => t.JobTitleId, cascadeDelete: true)
                .ForeignKey("dbo.Qualifications", t => t.QualificationsId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.TrackId)
                .Index(t => t.BranchId)
                .Index(t => t.JobTitleId)
                .Index(t => t.QualificationsId);
            
            CreateTable(
                "dbo.JobTitles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        University = c.String(nullable: false),
                        Faculty = c.String(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        GraduateDate = c.DateTime(nullable: false),
                        Department = c.String(nullable: false),
                        Grade = c.String(nullable: false, maxLength: 20),
                        Degree = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        GraduateId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Graduates", t => t.GraduateId)
                .Index(t => t.GraduateId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        GraduateId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Graduates", t => t.GraduateId)
                .Index(t => t.GraduateId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        GraduateId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Graduates", t => t.GraduateId)
                .Index(t => t.GraduateId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Website = c.String(nullable: false, maxLength: 100),
                        IsConfirmed = c.Boolean(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        NumberOfEmployees = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CV = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Companies", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Graduates", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.Skills", "GraduateId", "dbo.Graduates");
            DropForeignKey("dbo.Graduates", "QualificationsId", "dbo.Qualifications");
            DropForeignKey("dbo.Projects", "GraduateId", "dbo.Graduates");
            DropForeignKey("dbo.Graduates", "JobTitleId", "dbo.JobTitles");
            DropForeignKey("dbo.Interests", "GraduateId", "dbo.Graduates");
            DropForeignKey("dbo.Experiences", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Staffs", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.Staffs", "QualificationsId", "dbo.Qualifications");
            DropForeignKey("dbo.Staffs", "JobTitleId", "dbo.JobTitles");
            DropForeignKey("dbo.Staffs", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Staffs", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Experiences", "GraduateId", "dbo.Graduates");
            DropForeignKey("dbo.Certifications", "GraduateId", "dbo.Graduates");
            DropForeignKey("dbo.Graduates", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Graduates", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Articles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Admins", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Profiles", new[] { "Id" });
            DropIndex("dbo.Companies", new[] { "Id" });
            DropIndex("dbo.Skills", new[] { "GraduateId" });
            DropIndex("dbo.Projects", new[] { "GraduateId" });
            DropIndex("dbo.Interests", new[] { "GraduateId" });
            DropIndex("dbo.Staffs", new[] { "QualificationsId" });
            DropIndex("dbo.Staffs", new[] { "JobTitleId" });
            DropIndex("dbo.Staffs", new[] { "BranchId" });
            DropIndex("dbo.Staffs", new[] { "TrackId" });
            DropIndex("dbo.Staffs", new[] { "Id" });
            DropIndex("dbo.Experiences", new[] { "StaffId" });
            DropIndex("dbo.Experiences", new[] { "GraduateId" });
            DropIndex("dbo.Certifications", new[] { "GraduateId" });
            DropIndex("dbo.Graduates", new[] { "QualificationsId" });
            DropIndex("dbo.Graduates", new[] { "BranchId" });
            DropIndex("dbo.Graduates", new[] { "TrackId" });
            DropIndex("dbo.Graduates", new[] { "JobTitleId" });
            DropIndex("dbo.Graduates", new[] { "Id" });
            DropIndex("dbo.Articles", new[] { "UserId" });
            DropIndex("dbo.Admins", new[] { "Id" });
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropTable("dbo.Profiles");
            DropTable("dbo.Companies");
            DropTable("dbo.Skills");
            DropTable("dbo.Projects");
            DropTable("dbo.Interests");
            DropTable("dbo.Tracks");
            DropTable("dbo.Qualifications");
            DropTable("dbo.JobTitles");
            DropTable("dbo.Staffs");
            DropTable("dbo.Experiences");
            DropTable("dbo.Certifications");
            DropTable("dbo.Graduates");
            DropTable("dbo.Branches");
            DropTable("dbo.Articles");
            DropTable("dbo.Admins");
        }
    }
}
