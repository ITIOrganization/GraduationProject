namespace AlumniSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ProfileImage = c.String(),
                        Name = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        PostId = c.Int(nullable: false),
                        Body = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.PostId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(nullable: false),
                        PublishedDate = c.DateTime(nullable: false),
                        HaveImage = c.Boolean(nullable: false),
                        PubishedTime = c.Time(nullable: false, precision: 7),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.PostId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Complains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        SendDate = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.EventStates",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EventId = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.EventId })
                .ForeignKey("dbo.AspNetUsers", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsApproved = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        IsFinished = c.Boolean(nullable: false),
                        EventImage = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Image = c.String(),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        NotifyDate = c.DateTime(nullable: false),
                        NotifyTime = c.Time(nullable: false, precision: 7),
                        IsRead = c.Boolean(nullable: false),
                        Icon = c.String(),
                        Image = c.String(),
                        UserId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
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
                        Grade = c.Int(nullable: false),
                        Degree = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserMessages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FromId = c.String(nullable: false, maxLength: 128),
                        ToId = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        SendIn = c.DateTime(nullable: false),
                        IsSeen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.FromId })
                .ForeignKey("dbo.AspNetUsers", t => t.FromId, cascadeDelete: true)
                .Index(t => t.FromId);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        HeaderImage = c.String(),
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
                        Address = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Author = c.String(nullable: false),
                        ReferenceUrl = c.String(nullable: false),
                        CertificationNumber = c.String(nullable: false),
                        GraduateId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Graduates", t => t.GraduateId)
                .Index(t => t.GraduateId);
            
            CreateTable(
                "dbo.Graduates",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        JobTitleId = c.Int(nullable: false),
                        CareerObjective = c.String(maxLength: 500),
                        Intake = c.Int(nullable: false),
                        TrackId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.JobTitles", t => t.JobTitleId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.JobTitleId)
                .Index(t => t.TrackId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Location = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        IsCusrrentlyWorked = c.Boolean(nullable: false),
                        JobTitleId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Graduate_Id = c.String(maxLength: 128),
                        Staff_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.JobTitles", t => t.JobTitleId, cascadeDelete: true)
                .ForeignKey("dbo.Graduates", t => t.Graduate_Id)
                .ForeignKey("dbo.Staffs", t => t.Staff_Id)
                .Index(t => t.JobTitleId)
                .Index(t => t.UserId)
                .Index(t => t.Graduate_Id)
                .Index(t => t.Staff_Id);
            
            CreateTable(
                "dbo.JobTitles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
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
                        CreatedDate = c.DateTime(nullable: false),
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
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsersApplications",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        JobId = c.Int(nullable: false),
                        AppliedDate = c.DateTime(nullable: false),
                        IsApplied = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.JobId })
                .ForeignKey("dbo.Graduates", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        jobTitleID = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        GraduateType = c.Int(nullable: false),
                        JobType = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.JobTitles", t => t.jobTitleID, cascadeDelete: false)
                .Index(t => t.jobTitleID)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Website = c.String(nullable: false, maxLength: 100),
                        IsConfirmed = c.Boolean(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        NumberOfEmployees = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TrackId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        JobTitleId = c.Int(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.JobTitles", t => t.JobTitleId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.TrackId)
                .Index(t => t.BranchId)
                .Index(t => t.JobTitleId);
            
            CreateTable(
                "dbo.GroupApplicationUsers",
                c => new
                    {
                        Group_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Group_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Group_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.KeywordApplicationUsers",
                c => new
                    {
                        Keyword_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Keyword_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Keywords", t => t.Keyword_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Keyword_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.QualificationsApplicationUsers",
                c => new
                    {
                        Qualifications_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Qualifications_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Qualifications", t => t.Qualifications_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Qualifications_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.Staffs", "JobTitleId", "dbo.JobTitles");
            DropForeignKey("dbo.Experiences", "Staff_Id", "dbo.Staffs");
            DropForeignKey("dbo.Staffs", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Staffs", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Profiles", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Companies", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Certifications", "GraduateId", "dbo.Graduates");
            DropForeignKey("dbo.UsersApplications", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "jobTitleID", "dbo.JobTitles");
            DropForeignKey("dbo.Jobs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersApplications", "Id", "dbo.Graduates");
            DropForeignKey("dbo.Graduates", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.Skills", "GraduateId", "dbo.Graduates");
            DropForeignKey("dbo.Projects", "GraduateId", "dbo.Graduates");
            DropForeignKey("dbo.Graduates", "JobTitleId", "dbo.JobTitles");
            DropForeignKey("dbo.Interests", "GraduateId", "dbo.Graduates");
            DropForeignKey("dbo.Experiences", "Graduate_Id", "dbo.Graduates");
            DropForeignKey("dbo.Experiences", "JobTitleId", "dbo.JobTitles");
            DropForeignKey("dbo.Experiences", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Graduates", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Graduates", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Articles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Admins", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserMessages", "FromId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.QualificationsApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.QualificationsApplicationUsers", "Qualifications_Id", "dbo.Qualifications");
            DropForeignKey("dbo.Notifications", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.KeywordApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.KeywordApplicationUsers", "Keyword_Id", "dbo.Keywords");
            DropForeignKey("dbo.GroupApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.GroupApplicationUsers", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.EventStates", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventStates", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Complains", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Likes", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Likes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.QualificationsApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.QualificationsApplicationUsers", new[] { "Qualifications_Id" });
            DropIndex("dbo.KeywordApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.KeywordApplicationUsers", new[] { "Keyword_Id" });
            DropIndex("dbo.GroupApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.GroupApplicationUsers", new[] { "Group_Id" });
            DropIndex("dbo.Staffs", new[] { "JobTitleId" });
            DropIndex("dbo.Staffs", new[] { "BranchId" });
            DropIndex("dbo.Staffs", new[] { "TrackId" });
            DropIndex("dbo.Staffs", new[] { "Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Profiles", new[] { "Id" });
            DropIndex("dbo.Companies", new[] { "Id" });
            DropIndex("dbo.Jobs", new[] { "UserId" });
            DropIndex("dbo.Jobs", new[] { "jobTitleID" });
            DropIndex("dbo.UsersApplications", new[] { "JobId" });
            DropIndex("dbo.UsersApplications", new[] { "Id" });
            DropIndex("dbo.Skills", new[] { "GraduateId" });
            DropIndex("dbo.Projects", new[] { "GraduateId" });
            DropIndex("dbo.Interests", new[] { "GraduateId" });
            DropIndex("dbo.Experiences", new[] { "Staff_Id" });
            DropIndex("dbo.Experiences", new[] { "Graduate_Id" });
            DropIndex("dbo.Experiences", new[] { "UserId" });
            DropIndex("dbo.Experiences", new[] { "JobTitleId" });
            DropIndex("dbo.Graduates", new[] { "BranchId" });
            DropIndex("dbo.Graduates", new[] { "TrackId" });
            DropIndex("dbo.Graduates", new[] { "JobTitleId" });
            DropIndex("dbo.Graduates", new[] { "Id" });
            DropIndex("dbo.Certifications", new[] { "GraduateId" });
            DropIndex("dbo.Articles", new[] { "UserId" });
            DropIndex("dbo.UserMessages", new[] { "FromId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Notifications", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Events", new[] { "UserId" });
            DropIndex("dbo.EventStates", new[] { "EventId" });
            DropIndex("dbo.EventStates", new[] { "Id" });
            DropIndex("dbo.Complains", new[] { "UserId" });
            DropIndex("dbo.Likes", new[] { "PostId" });
            DropIndex("dbo.Likes", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Admins", new[] { "Id" });
            DropTable("dbo.QualificationsApplicationUsers");
            DropTable("dbo.KeywordApplicationUsers");
            DropTable("dbo.GroupApplicationUsers");
            DropTable("dbo.Staffs");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Profiles");
            DropTable("dbo.Companies");
            DropTable("dbo.Jobs");
            DropTable("dbo.UsersApplications");
            DropTable("dbo.Tracks");
            DropTable("dbo.Skills");
            DropTable("dbo.Projects");
            DropTable("dbo.Interests");
            DropTable("dbo.JobTitles");
            DropTable("dbo.Experiences");
            DropTable("dbo.Graduates");
            DropTable("dbo.Certifications");
            DropTable("dbo.Branches");
            DropTable("dbo.Articles");
            DropTable("dbo.UserMessages");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Qualifications");
            DropTable("dbo.Notifications");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Keywords");
            DropTable("dbo.Groups");
            DropTable("dbo.Events");
            DropTable("dbo.EventStates");
            DropTable("dbo.Complains");
            DropTable("dbo.Likes");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Admins");
        }
    }
}
