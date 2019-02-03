using System.ComponentModel.DataAnnotations;

namespace MatesCarSite.ViewModels
{
    public class CreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; } 
        [Required]
        public string Password { get; set; }

    }
    public class EditModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [UIHint("email")]
        public string Email { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
