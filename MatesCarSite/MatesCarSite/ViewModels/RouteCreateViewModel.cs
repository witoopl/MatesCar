using MatesCarSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.ViewModels
{
    public class RouteCreateViewModel : Route
    {
        public new string[] Passengers { get; set; }
    }
}
