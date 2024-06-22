using System.ComponentModel.DataAnnotations;

namespace icbf_web.Models
{
    public class EditUsuarioViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Display(Name = "Cedula")]
        public long? Cedula { get; set; }
              [Display(Name = "Telefono")]
        public long? Telefono { get; set; }

        public string Rol { get; set; }
        public bool Estado { get; set; }
        

    }
}
