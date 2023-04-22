using System.ComponentModel.DataAnnotations;

namespace Web.Identity.Demo.ViewModels
{
    public class RoleAddViewModel
    {
        [Required]
        public string? RoleName { get; set; }
    }
}
