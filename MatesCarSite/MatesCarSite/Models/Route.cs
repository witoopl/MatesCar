using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.Models
{
    public class Route
    {
        public string Id { get; set; }
        public Road Road { get; set; }
        public Car Car { get; set; }
        public ApplicationUser Driver { get; set; }
        public ApplicationUser Passenger { get; set; }
        float ChargeForPassenger { get; set; }
        bool IsFullyPaid { get; set; }
    }
}
