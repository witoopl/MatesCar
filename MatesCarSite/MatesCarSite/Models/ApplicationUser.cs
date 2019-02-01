using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.Models
{
    /// <summary>
    /// The user data and profile for our application
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public Car Car { get; set; }
        public string LastLocation { get; set; }
        [MaxLength(32)]
        public string DefaultBankAccount { get; set; }
        public bool BankAccountVerificated { get; set; } = false;
        public bool IsDriver { get; set; } = false;

        
    }

}
