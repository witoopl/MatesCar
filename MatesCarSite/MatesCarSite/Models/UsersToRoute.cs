using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.Models
{
    public class UsersToRoute
    {
        [Key]
        public string Id { get; set; }
        public Route RouteRef { get; set; }
        public ApplicationUser PassengerRef { get; set; }
    }
}
