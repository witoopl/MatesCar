﻿using MatesCarSite;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite
{

    /// <summary>
    /// A shortgand access class to get DI services with nice clean short code
    /// </summary>
    public static class IoC
    {

        /// <summary>
        /// The scoped instance of the <see cref="ApplicationDbContext"/>
        /// </summary>
        public static ApplicationDbContext ApplicationDbContext => IoCContainer.Provider.GetService<ApplicationDbContext>();
    }


    /// <summary>
    /// The dependency injection container making use of built in .Net Core service provider
    /// </summary>
    public static class IoCContainer
    {

        /// <summary>
        /// The service provider for this application
        /// </summary>
        public static ServiceProvider Provider {get; set;}
    }
}
