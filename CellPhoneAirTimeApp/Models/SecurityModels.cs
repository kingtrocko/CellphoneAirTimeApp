using System.ComponentModel.DataAnnotations;

namespace CellPhoneAirTimeApp.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Dirección 1")]
        public string Address1 { get; set; }

        [Required]
        [Display(Name = "Dirección 2")]
        public string Address2 { get; set; }

        [Required]
        [Display(Name = "Número de Teléfono")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Mi Correo")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}