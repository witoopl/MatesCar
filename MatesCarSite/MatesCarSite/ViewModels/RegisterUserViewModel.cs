using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.ViewModels
{
    public class RegisterUserViewModel
    {
        [MaxLength(64)]
        [Required(ErrorMessageResourceName = "UsernameIsRequired", ErrorMessageResourceType =typeof(Resources.Errors))]
        [Key]
        [Display(Name = "Nazwa użytkownika")]
        public string Username { get; set; }
        [MaxLength(64)]
        [Required]
        [Key]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmail",ErrorMessageResourceType =typeof(Resources.Errors))]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [MaxLength(64,ErrorMessageResourceName = "TooLongName",ErrorMessageResourceType =typeof(Resources.Errors))]
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [MaxLength(64, ErrorMessageResourceName = "TooLongSurname", ErrorMessageResourceType = typeof(Resources.Errors))]
        [Required]
        [MinLength(2)]
        public string Surname { get; set; }
        public bool IsDriver { get; set; }
        [Phone(ErrorMessageResourceName = "InvalidPhone", ErrorMessageResourceType = typeof(Resources.Errors))]
        public string PhoneNumber { get; set; }
        public string BankAccount { get; set; }
    }
}
