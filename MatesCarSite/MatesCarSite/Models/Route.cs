using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.Models
{
    public class Route
    {
        [Key]
        public string Id{ get; set; }
        [Display(ResourceType = typeof(Resources.ColumnNamesForRoutes), Name = "Driver")]
        public ApplicationUser Driver { get; set; }
        [Required]
        public string StartLocation { get; set; }
        [Required]
        public string EndLocation { get; set; }
        [Required]
        public float FuelUsage { get; set; }
        [Required]
        public float ChargeForPassenger { get; set; }
        [Required]
        public bool IsFullyPaid { get; set; }
        
        
    }
}
