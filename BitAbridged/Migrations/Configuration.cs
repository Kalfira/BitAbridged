using BitAbridged.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;

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
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

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
            if (!userManager.Users.Any())
            {
                userManager.Create(zane, "12341234");
                userManager.AddToRole(zane.Id, "Admin");
            }


            var BaseLanguages = new List<Language>
            {
                new Language{Id = 0,Name = "Basic", Url = "language({lang: 'Basic'})", Use = "Application and Education", Imperative = true,ObjectOriented = false, Functional = false,Procedural = true,Generic = false,Reflective = false,EventDriven = false,Standardized = "1983, ANSI, ISO"},
                new Language{Id = 1,Name = "C", Url = "language({lang: 'C'})", Use = "Application, system, and general purpose low level applications", Imperative = true,ObjectOriented = false, Functional = false,Procedural = true,Generic = false,Reflective = false,EventDriven = false,Standardized = "1989, ANSI C89, ISO C90, ISO C99, ISO C11"},
                new Language{Id = 2,Name = "CPlusPlus", Url = "language({lang: 'CPlusPlus'})",  Use = "Application and System development",Imperative = true,ObjectOriented = true, Functional = true,Procedural = true,Generic = true,Reflective = false,EventDriven = false,Standardized = "1998, ISO/IEC 1998, ISO/IEC 2003, ISO/IEC 2011"},
                new Language{Id = 3,Name = "CSharp", Url = "language({lang: 'CSharp'})",  Use = "Application, RAD, business, client-side, general, server-side, and web based application",Imperative = true,ObjectOriented = true, Functional = true,Procedural = true,Generic = true,Reflective = true,EventDriven = true,Standardized = "2000, ECMA, ISO"},
                new Language{Id = 4,Name = "Python", Url = "language({lang: 'Python'})",  Use = "Application, general, Web, scripting, artificial intelligence, and scientific computing",Imperative = true,ObjectOriented = true, Functional = true,Procedural = true,Generic = true,Reflective = true,EventDriven = false,Standardized = "NO"},
                new Language{Id = 5,Name = "Haskell", Url = "language({lang: 'Haskell'})",  Use = "Application",Imperative = false,ObjectOriented = false, Functional = true,Procedural = false,Generic = true,Reflective = false,EventDriven = false,Standardized = "2010, Haskell 2010"},
                new Language{Id = 6,Name = "Powershell", Url = "language({lang: 'Powershell'})",  Use = "Administration",Imperative = true,ObjectOriented = true, Functional = true,Procedural = false,Generic = false,Reflective = true,EventDriven = false,Standardized = "No"},
                new Language{Id = 7,Name = "Java", Url = "language({lang: 'Java'})",  Use = "Application, business, client-side, general, mobile development, server-side, and web applications",Imperative = true,ObjectOriented = true, Functional = true,Procedural = true,Generic = true,Reflective = true,EventDriven = false,Standardized = "De facto standard via Java Language Specification"},
                new Language{Id = 8,Name = "Perl", Url = "language({lang: 'Perl'})",  Use = "Application, scripting, text processing, and web applications",Imperative = true,ObjectOriented = true, Functional = true,Procedural = true,Generic = true,Reflective = true,EventDriven = false,Standardized = "No"},
                new Language{Id = 9,Name = "PHP", Url = "language({lang: 'PHP'})",  Use = "Server side and web application processing",Imperative = true,ObjectOriented = true, Functional = false,Procedural = true,Generic = false,Reflective = true,EventDriven = false,Standardized = "No"},
                new Language{Id = 10,Name = "Javascript", Url = "language({lang: 'Javascript'})",  Use = "Client-side, Server-side, and web applications",Imperative = true,ObjectOriented = true, Functional = true,Procedural = false,Generic = false,Reflective = true,EventDriven = false,Standardized = "1997, ECMA"},
                new Language{Id = 11,Name = "Fortran",Url = "language({lang: 'Fortran'})",Use = "Application and Numerical computing", Imperative = true,ObjectOriented = true,Functional = false,Procedural = true,Generic = true, Reflective = false, EventDriven = false, Standardized = "1966, ANSI 66, ANSI 77, MIL-STD-1753, ISO 90, ISO 95, ISO 2003, ISO/IEC 1539-1:2010 (2008)"}

                
                
                //new Searchable{Id = 2, Name = "Java", Description = "Class based, object oriented language with few implementation dependencies", Url = "language({lang: 'Java'})"},
                //new Searchable{Id = 3, Name = "Perl", Description = "General purpose language that specializes in text processing", Url = "language({lang: 'Perl'})"},
                //new Searchable{Id = 4, Name = "Home", Description = "Home Page", Url = "home"},
                //new Searchable{Id = 5, Name = "Login", Description = "Login Page", Url = "login"},
                //new Searchable{Id = 6, Name = "Languages", Description = "Languages Landing Page", Url = "languages"}
            };

            foreach (var item in BaseLanguages)
            {
                context.Languages.AddOrUpdate(item);
            }
            context.SaveChanges();


        }
    }
}
