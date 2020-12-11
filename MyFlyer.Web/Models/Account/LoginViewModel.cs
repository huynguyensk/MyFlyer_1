using System.ComponentModel.DataAnnotations;

namespace MyFlyer.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        public string UsernameOrEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}