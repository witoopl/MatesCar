using MatesCarSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace MatesCarSite
{
    /// <summary>
    /// The database representational model for out application
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        #region Public properties
        public DbSet<Car> Cars { get; set; }
        public DbSet<Debt> Debts { get; set; }

        public DbSet<Road> Roads { get; set; }
        public DbSet<Route> Routes { get; set; }
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

           // modelBuilder.Entity<SettingsDataModel>().HasIndex(a => a.Name);
        }
    }
}
