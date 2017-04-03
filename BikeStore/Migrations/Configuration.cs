namespace BikeStore.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BikeStore.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BikeStore.Models.ApplicationDbContext context)
        {


            //var store = new RoleStore<IdentityRole>(context);
            //var manager = new RoleManager<IdentityRole>(store);
            //var AdminRole = new IdentityRole { Name = "Admin" };
            //var ModeratorRole = new IdentityRole { Name = "Moderator" };
            //manager.Create(AdminRole);
            //manager.Create(ModeratorRole);
            //context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //{
            //    Name = "Admin"
            //});
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            {
                Name = "Moderator"
            });


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
