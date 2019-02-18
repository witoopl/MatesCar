using MatesCarSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatesCarSite
{
    /// <summary>
    /// The database representational model for out application
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        #region Public properties
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<UsersToRoute> UsersToRoutes {get; set;}
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor, expecting database options passed in
        /// </summary>
        /// <param name="options">The database context options</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base (options)
        {

        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Fluent API

            modelBuilder.Entity<ApplicationUser>().HasIndex(e => e.Email).IsUnique();
        }

        public static async Task CreateAdminAccountAndBasicRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = configuration["Data:AdminUser:Name"];
            string email = configuration["Data:AdminUser:Email"];
            string password = configuration["Data:AdminUser:Password"];
            string role = configuration["Data:AdminUser:Role"];
            string userFirstName = configuration["Data:AdminUser:UserFirstName"];
            string userSurname = configuration["Data:AdminUser:UserSurname"];
            string usersRoles = configuration["Data:AdminUser:UsersRoles"];

            if (await userManager.FindByNameAsync(username) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                if (await roleManager.FindByNameAsync(usersRoles) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(usersRoles));
                }
                ApplicationUser user = new ApplicationUser
                {
                    UserName = username,
                    Email = email,
                    UserFirstName = userFirstName,
                    UserSurname = userSurname
                };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
