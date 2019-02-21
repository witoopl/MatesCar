using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.Models
{
    public class Debt
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public ApplicationUser LoanHolderRef { get; set; }
        public ApplicationUser LoanDebtorRef { get; set; }
        [Required]
        public float Value { get; set; }
        public Route RouteRef { get; set; }
        


    }
}
