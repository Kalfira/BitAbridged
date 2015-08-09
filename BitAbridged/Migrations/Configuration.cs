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
                new Language{Id = 0,Name = "Basic", Url = "language({lang: 'Basic'})", Use = "Application and Education", Imperative = true,ObjectOriented = false, Functional = false,Procedural = true,Generic = false,Reflective = false,EventDriven = false,Standardized = "1983 ANSI, ISO", FF1 = "First appeared in 1964", FF2 = "Designed by John Kemeny and Thomas Kurtz", FF3 = "Formed during transition period from mainframe to more multi processor computers", FF4 = "Based on FORTRAN"},
                new Language{Id = 1,Name = "C", Url = "language({lang: 'C'})", Use = "Application, system, and general purpose low level applications", Imperative = true,ObjectOriented = false, Functional = false,Procedural = true,Generic = false,Reflective = false,EventDriven = false,Standardized = "1989 ISO and C90", FF1 = "First appeared in 1972", FF2 = "Designed by Dennis Ritchie and Bell Labs", FF3 = "Many languages borrow directly and indirectly from C", FF4 = "Very commonly used as an intermediate language for other languages"},
                new Language{Id = 2,Name = "CPlusPlus", Url = "language({lang: 'CPlusPlus'})",  Use = "Application and System development",Imperative = true,ObjectOriented = true, Functional = true,Procedural = true,Generic = true,Reflective = false,EventDriven = false,Standardized = "1998 ISO/IEC and 2011 ISO/IEC", FF1 = "First appeared in 1983", FF2 = "Designed by Bjarne Stroustrup", FF3 = "Founded on C language", FF4 = "Influenced Perl, Lua, Java, PHP and C#"},
                new Language{Id = 3,Name = "CSharp", Url = "language({lang: 'CSharp'})",  Use = "Application, RAD, business, client-side, general, server-side, and web based application",Imperative = true,ObjectOriented = true, Functional = true,Procedural = true,Generic = true,Reflective = true,EventDriven = true,Standardized = "2000 ECMA and ISO", FF1 = "First appeared in 2000", FF2 = "Designed by Microsoft", FF3 = "Uses Common Language Runtime compilation for speed at runtime", FF4 = ".Net Framework family language"},
                new Language{Id = 4,Name = "Python", Url = "language({lang: 'Python'})",  Use = "Application, general, Web, scripting, artificial intelligence, and scientific computing",Imperative = true,ObjectOriented = true, Functional = true,Procedural = false,Generic = false,Reflective = true,EventDriven = false,Standardized = "No", FF1 = "First appeared in 1991", FF2 = "Designed by Guido van Rossum", FF3 = "Named after Monty Python comedy troupe", FF4 = "Designed to support functional programming similar to Lisp and Haskell"},
                new Language{Id = 5,Name = "Haskell", Url = "language({lang: 'Haskell'})",  Use = "Application",Imperative = false,ObjectOriented = false, Functional = true,Procedural = false,Generic = true,Reflective = false,EventDriven = false,Standardized = "2010, Haskell 2010", FF1 = "First appeared in 1990", FF2 = "Named after logician Haskell Curry", FF3 = "Purely functional language", FF4 = "Multiple current implimentations"},
                new Language{Id = 6,Name = "Powershell", Url = "language({lang: 'Powershell'})",  Use = "Administration",Imperative = true,ObjectOriented = true, Functional = true,Procedural = false,Generic = false,Reflective = true,EventDriven = false,Standardized = "No", FF1 = "First appeared in 2006", FF2 = "Designed by Microsoft", FF3 = "Designed as a scripting / administration tool", FF4 = ".Net Framework family language"},
                new Language{Id = 7,Name = "Java", Url = "language({lang: 'Java'})",  Use = "Application, business, client-side, general, mobile development, server-side, and web applications",Imperative = true,ObjectOriented = true, Functional = true,Procedural = true,Generic = true,Reflective = true,EventDriven = false,Standardized = "De facto standard", FF1 = "First appeared in 1995", FF2 = "Designed by James Gosling and Sun Microsystems", FF3 = "Designed for interactive televsion but was too advanced for hardware of the time", FF4 = "Typically considered slower than C++ but easier to manage"},
                new Language{Id = 8,Name = "Perl", Url = "language({lang: 'Perl'})",  Use = "Application, scripting, text processing, and web applications",Imperative = true,ObjectOriented = true, Functional = true,Procedural = true,Generic = true,Reflective = true,EventDriven = false,Standardized = "No", FF1 = "First appeared in 1987", FF2 = "Designed by Larry Wall", FF3 = "Implimented in C", FF4 = "Distinct split between Perl 5 release and Perl 6"},
                new Language{Id = 9,Name = "PHP", Url = "language({lang: 'PHP'})",  Use = "Server side and web application processing",Imperative = true,ObjectOriented = true, Functional = false,Procedural = true,Generic = false,Reflective = true,EventDriven = false,Standardized = "No", FF1 = "First appeared in 1995", FF2 = "Designed by Rasmus Lerdorf", FF3 = "Typically used as a server side scripting language but can be used as a general purpose option", FF4 = "Implimented in C"},
                new Language{Id = 10,Name = "Javascript", Url = "language({lang: 'Javascript'})",  Use = "Client-side, Server-side, and web applications",Imperative = true,ObjectOriented = true, Functional = true,Procedural = false,Generic = false,Reflective = true,EventDriven = false,Standardized = "1997, ECMA", FF1 = "First appeared in 1995", FF2 = "Designed by Brendan Eich", FF3 = "Associated with scripting for web browsers but can be implimented in many ways", FF4 = "Originally developed for Netscape"},
                new Language{Id = 11,Name = "Fortran",Url = "language({lang: 'Fortran'})",Use = "Application and Numerical computing", Imperative = true,ObjectOriented = true,Functional = false,Procedural = true,Generic = true, Reflective = false, EventDriven = false, Standardized = "1966 ANSI and ISO/IEC (2008)", FF1 = "First appeared in 1957", FF2 = "Designed by John Backus", FF3 = "Originally developed by IBM", FF4 = "Extremely high performing language"}
            };

            foreach (var item in BaseLanguages)
            {
                context.Languages.AddOrUpdate(item);
            }
            context.SaveChanges();


        }
    }
}
