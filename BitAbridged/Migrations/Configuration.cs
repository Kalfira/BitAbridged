using BitAbridged.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace BitAbridged.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BitAbridged.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BitAbridged.Models.ApplicationDbContext context)
        {
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            RoleStore<Role> roleStore = new RoleStore<Role>(context);
            RoleManager<Role> roleManager = new RoleManager<Role>(roleStore);

            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new Role { Name = "Admin" });

            if (!roleManager.RoleExists("User"))
                roleManager.Create(new Role { Name = "User" });
            ApplicationUser zane = userManager.FindByName("zdegner@gmail.com");

            zane = new ApplicationUser
            {
                Id = "1",
                UserName = "admin",
                Email = "zdegner@gmail.com"
            };
            userManager.Create(zane, "12341234");
            userManager.AddToRole(zane.Id, "Admin");

            var BaseLanguages = new List<Searchable>
            {
                new Searchable{Id = 1, Name = "C",Description = "General purpose, low-level programming language.", Url = "c"},
                new Searchable{Id = 2, Name = "Java", Description = "Class based, object oriented language with few implementation dependencies", Url = "java"},
                new Searchable{Id = 3, Name = "Perl", Description = "General purpose language that specializes in text processing", Url = "perl"},
                new Searchable{Id = 4, Name = "Home", Description = "Home Page", Url = "home"},
                new Searchable{Id = 4, Name = "Demo", Description = "Demo Page", Url = "demo"},
                new Searchable{Id = 5, Name = "Login", Description = "Login Page", Url = "login"}
            };

            foreach (var item in BaseLanguages)
            {
                context.Searchables.AddOrUpdate(item);
            }
            context.SaveChanges();


        }
    }
}
