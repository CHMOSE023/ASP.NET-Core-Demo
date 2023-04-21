using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Identity.ViewsModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name="用户名")]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string? PassWorld { get; set; }
    }
}
