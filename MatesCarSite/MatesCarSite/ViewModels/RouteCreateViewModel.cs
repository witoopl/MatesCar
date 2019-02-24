using MatesCarSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MatesCarSite.ViewModels
{
    public class RouteCreateViewModel
    {

        [Required(ErrorMessageResourceName = "StartLocation", ErrorMessageResourceType = typeof(Resources.Errors))]
        public string StartLocation { get; set; }
        [Required(ErrorMessageResourceName = "EndLocation", ErrorMessageResourceType = typeof(Resources.Errors))]
        public string EndLocation { get; set; }
        [Required(ErrorMessageResourceName = "FuelUsage", ErrorMessageResourceType = typeof(Resources.Errors))]
        public float FuelUsage { get; set; }
        //[Required(ErrorMessageResourceName = "Passengers", ErrorMessageResourceType = typeof(Resources.Errors))]
        public List<ApplicationUser> Passengers { get; set; }
        [Required(ErrorMessageResourceName = "ChargeForPassenger", ErrorMessageResourceType = typeof(Resources.Errors))]
        public float ChargeForPassenger { get; set; }
        public DateTime RouteDateTime { get; set; }

    }
}
