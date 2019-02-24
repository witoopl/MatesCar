using MatesCarSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.ViewModels
{
    public class RouteDetailsViewModel : Route
    {
        public List<ApplicationUser> PassengersInRoute { get; set; }
    }
}
