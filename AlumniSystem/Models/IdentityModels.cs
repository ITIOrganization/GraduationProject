using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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

        [Required]
        public string Name { get; set; }

        [Range(18,100)]
        public int Age { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual List<EventState> EventStates { get; set; }

        public virtual List<Post> Posts { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<UserMessages> UserMessages { get; set; }

        public virtual List<Complain> Complains { get; set; }

    }

    public class ApplicationRole : IdentityRole
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Admin> Admin { get; set; }

        public virtual DbSet<Article> Article { get; set; }

        public virtual DbSet<Branch> Branche { get; set; }

        public virtual DbSet<Certification> Certification { get; set; }

        public virtual DbSet<Comment> Comment { get; set; }

        public virtual DbSet<Company> Company { get; set; }

        public virtual  DbSet<Complain> Complain { get; set; }

        public virtual DbSet<Event> Event { get; set; }

        public virtual DbSet<EventState> EventState { get; set; }

        public virtual DbSet<Experience> Experience { get; set; }

        public virtual DbSet<Graduate> Graduate { get; set; }

        public virtual DbSet<Interest> Interest { get; set; }

        public virtual DbSet<Like> Like { get; set; }

        public virtual DbSet<Message> Message { get; set; }

        public virtual DbSet<Post> Post { get; set; }

        public virtual DbSet<Profile> Profile { get; set; }

        public virtual DbSet<Project> Project { get; set; }

        public virtual DbSet<Qualifications> Qualifications { get; set; }

        public virtual DbSet<Skill> Skill { get; set; }

        public virtual DbSet<Staff> Staff{ get; set; }

        public virtual DbSet<Track> Track { get; set; }

        public virtual DbSet<UserMessages> UserMessage { get; set; }
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