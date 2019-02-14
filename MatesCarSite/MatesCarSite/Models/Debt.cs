using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.Models
{
    public class Debt
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public ApplicationUser NameOfLoanHolder { get; set; }
        [Required]
        public List<ApplicationUser> NameOfDebtor { get; set; }
        [Required]
        public float Value { get; set; }
        public Route Route { get; set; }
        


    }
}
