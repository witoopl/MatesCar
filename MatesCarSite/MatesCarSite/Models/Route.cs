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
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id{ get; set; }
        [Required]
        public string StartLocation { get; set; }
        [Required]
        public string EndLocation { get; set; }
        [Required]
        public float FuelUsage { get; set; }
        [Required]
        public ApplicationUser Driver { get; set; }
        [Required]
        public List<ApplicationUser> Passengers{ get; set; }
        [Required]
        public float ChargeForPassenger { get; set; }
        [Required]
        public bool IsFullyPaid { get; set; }
    }
}
