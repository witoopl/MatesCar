using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string DefaultBankAccount { get; set; }
        public bool IsDriver { get; set; } = false;

        [Required]
        public string UserFirstName { get; set; }
        [Required]
        public string UserSurname { get; set; }
        public List<ApplicationUser> Friends { get; set; }


    }

}
