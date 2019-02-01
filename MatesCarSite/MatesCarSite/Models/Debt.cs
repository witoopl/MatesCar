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
        public string NameOfLoanHolder { get; set; }
        [Required]
        public string NameOfDebtor { get; set; }
        [Required]
        public float Value { get; set; }
        public ApplicationUser AssociatedUser { get; set; }


    }
}
