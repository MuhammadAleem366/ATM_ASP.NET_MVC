namespace ATM_ASP.NET_MVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ATM_ASP.NET_MVC.Services;
    using ATM_ASP.NET_MVC.Models;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<ATM_ASP.NET_MVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ATM_ASP.NET_MVC.Models.ApplicationDbContext";
        }

        protected override void Seed(ATM_ASP.NET_MVC.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            
            if(!context.Users.Any(usr=>usr.UserName == "admin366"))
            {
                var user = new ApplicationUser 
                {
                    UserName= "admin366",
                    Email= "admin366@gmail.com"
                };
                userManager.Create(user, "$Aa123");
                
                var service = new CheckingAccountService(context);
                service.CreateAccount("admin366", "user", 1000, user.Id);
                context.Roles.AddOrUpdate(rol => rol.Name, new IdentityRole { Name="Admin"});
                context.SaveChanges();

                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
