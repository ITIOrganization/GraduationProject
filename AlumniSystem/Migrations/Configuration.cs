namespace AlumniSystem.Migrations
{
    using AlumniSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AlumniSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AlumniSystem.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Roles.AddOrUpdate(

                new ApplicationRole() { Id = "1", Name = "Admin" },
                new ApplicationRole() { Id = "2", Name = "Staff" },
                new ApplicationRole() { Id = "3", Name = "Graduate" },
                new ApplicationRole() { Id = "4", Name = "Company" }

            );
        }
    }
}
