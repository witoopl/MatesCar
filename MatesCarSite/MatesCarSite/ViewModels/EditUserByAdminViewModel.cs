using System.ComponentModel.DataAnnotations;

namespace MatesCarSite.ViewModels
{
    public class EditUserByAdminViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
