using System.ComponentModel.DataAnnotations;

namespace FilmsList.API.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password don't match")]
        public string ConfirmPassword { get; set; }
        
    }
}