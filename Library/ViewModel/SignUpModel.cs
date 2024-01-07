using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class SignUpModel
    {
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Le nom d'utilisateur est nécessaire")]
        public string? UserName { get; set; }
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "Le Prénom est nécessaire")]
        public string? FirstName { get; set; }
        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Le Nom est nécessaire")]
        public string? LastName { get; set; }

        [Display(Name = "DateOfBirth")]
        [Required(ErrorMessage = "La date de naissance est nécessaire")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "L'email est nécessaire")]
        [EmailAddress(ErrorMessage = "L'email n'est pas dans un format valide")]
        public string? Email { get; set; }

        [Display(Name = "PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Le mot de passe est nécessaire")]
        public string? Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirmez le mot de passe")]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string ConfirmPassword { get; set; }
    }
}
