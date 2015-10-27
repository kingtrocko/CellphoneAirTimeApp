using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellPhoneAirTimeApp.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "El campo 'Primer Nombre' es requerido")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "El campo 'Primer Apellido es requerido'")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        public string FullName { get; set; }

        [Required(ErrorMessage = "El campo 'Direccion 1' es requerido")]
        [Display(Name = "Dirección 1")]
        public string Address1 { get; set; }

        [Display(Name = "Dirección 2")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "El campo 'Número de Teléfono es requerido'")]
        [Display(Name = "Número de Teléfono")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "El campo 'Mi correo' es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo 'Usuario' es requerido")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
    }

    public class ResetPasswordModel
    {
        [Required]
        [StringLength(16, ErrorMessage = "La {0} debe tener al menos {2} carácteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las constraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}