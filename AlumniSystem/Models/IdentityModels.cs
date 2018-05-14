using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace AlumniSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


        public string ProfileImage { get; set; }
        [Required]
        public string Name { get; set; }

        [DateOfBirthValidate]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual List<EventState> EventStates { get; set; }

        public virtual List<Post> Posts { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<UserMessages> UserMessages { get; set; }

        public virtual List<Complain> Complains { get; set; }

        public virtual List<Like> Likes { get; set; }

        public virtual List<Qualifications> Qualifications { get; set; }

        public virtual List<Notification> Notifications { get; set; }

        public virtual List<Group> Groups { get; set; }

        public virtual List<Keyword> Keywords { get; set; }



    }

    public class ApplicationRole : IdentityRole
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Admin> Admins { get; set; }

        public virtual DbSet<Article> Articles { get; set; }

        public virtual DbSet<Branch> Branches { get; set; }

        public virtual DbSet<Certification> Certifications { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Company> Companies { get; set; }

        public virtual  DbSet<Complain> Complains { get; set; }

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<EventState> EventStates { get; set; }

        public virtual DbSet<Experience> Experiences { get; set; }

        public virtual DbSet<Graduate> Graduates { get; set; }

        public virtual DbSet<Interest> Interests { get; set; }

        public virtual DbSet<Like> Likes { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Profile> Profiles { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<Qualifications> Qualifications { get; set; }

        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<Staff> Staff{ get; set; }

        public virtual DbSet<Track> Tracks { get; set; }

        public virtual DbSet<UserMessages> UserMessages { get; set; }

        public virtual DbSet<Notification> Notifications { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<Keyword> Keywords { get; set; }

        public virtual DbSet<UsersApplications> UsersApplications { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}