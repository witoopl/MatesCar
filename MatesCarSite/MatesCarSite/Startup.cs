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
            IoCContainer.Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add applicationDbContext to DI
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(IoCContainer.Configuration.GetConnectionString("DefaultConnection")));

            //AddIdentity adds coockie based authentication
            //Adds scoped classes for things like UserManger, SignInMananger, PasswordHashers etc...
            //NOTE: Atomatically adds the validated user from a cookie to the HttpContext.User
            services.AddIdentity<ApplicationUser, IdentityRole>()

                //Adds UserStore and RoleStore from this context
                //That are consumed by the UserMangaer an RoleManager
                .AddEntityFrameworkStores<ApplicationDbContext>()
                
                //Adds a provider that generates unique keys and hashes for things like
                // forgot password links, phone number verification codes etc...
                .AddDefaultTokenProviders();

           
            //Change password policy
            services.Configure<IdentityOptions>(options =>
            {
                //make really weak passwords ppossible
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });


            //Alter application cookie info
            services.ConfigureApplicationCookie(options =>
            {
                //Redirect to /login
                options.LoginPath = "/login";
                //options.DataProtectionProvider = DataProtectionProvider.Create("Test");
                //Change cookie timeout to expire in 5 days
                options.ExpireTimeSpan = TimeSpan.FromDays(5);
               
            });
            


            services.AddMvc(options =>
            {
                options.InputFormatters.Add(new XmlSerializerInputFormatter());
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            //Store instance of the DI service provider so our application can access it anywhere
            IoCContainer.Provider = (ServiceProvider)serviceProvider;

            //Setup identity
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{moreInfo?}");

                routes.MapRoute(
                    name: "aboutPage",
                    template: "more",
                    defaults: new { controller = "About", action = "TellMeMore" });
            });
        }
    }
}
