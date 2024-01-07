using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class LoginModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "L'email est nécessaire")]
        public string? Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Le mot de passe est nécessaire")]
        public string? Password { get; set; }
    }
}
