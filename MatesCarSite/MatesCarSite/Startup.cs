using MatesCarSite.Infrastructure;
using MatesCarSite.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MatesCarSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add applicationDbContext to DI
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                else
                    options.UseSqlServer(Configuration.GetConnectionString("DevelopmentConnection"));


                //Infrastructure.GetAllEvsClass.zasadyAplikacji = Environment.GetEnvironmentVariables();
            });





            //Automatically perform database migration. Only when on Azure server
            //
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.Migrate();


            //AddIdentity adds coockie based authentication
            //Adds scoped classes for things like UserManger, SignInMananger, PasswordHashers etc...
            //NOTE: Atomatically adds the validated user from a cookie to the HttpContext.User
            services.AddIdentity<ApplicationUser, IdentityRole>()

                //Adds UserStore and RoleStore from this context
                //That are consumed by the UserMangaer an RoleManager
                .AddEntityFrameworkStores<ApplicationDbContext>()

                //Adds a provider that generates unique keys and hashes for things like
                // forgot password links, phone number verification codes etc...
                .AddDefaultTokenProviders()
                //Adds polish messeges for Model errors TODO: region detection
                .AddErrorDescriber<PolishModelErrors>();

           
            //Change password policy
            services.Configure<IdentityOptions>(options =>
            {
                //make really weak passwords ppossible
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            });


            //Alter application cookie info
            services.ConfigureApplicationCookie(options =>
            {
                //Redirect to users/login
                //options.LoginPath = "/Users/login";
                //options.DataProtectionProvider = DataProtectionProvider.Create("Test");
                //Change cookie timeout to expire in 5 days
                options.ExpireTimeSpan = TimeSpan.FromDays(5);
               
            });



            services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseBrowserLink();
            }


            //use wwwroot files
            app.UseStaticFiles();

            //Setup identity
            app.UseAuthentication();

            //use default routes
            app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(name: "default", template: "{controller=Account}/{action=Login}");
            //});
           


            
            ApplicationDbContext.CreateAdminAccountAndBasicRoles(serviceProvider, Configuration).Wait();

            
        }
    }
}
