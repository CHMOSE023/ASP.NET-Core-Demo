using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Web.Identity.ViewsModels
{
    public class RegisterViewModels
    {
        [Required]
        [Display(Name = "用户名")]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string? PassWorld { get; set; }
    }
}
