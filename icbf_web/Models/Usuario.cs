using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace icbf_web.Models
{
    public class Usuario: IdentityUser
    {
        public string? Nombres { get; set; }
        public string? Direccion { get; set; }
       
        public long? Cedula { get; set; }
        public long? Telefono { get; set; }
        public bool Estado { get; set; }
        public ICollection<MadreComunitaria> MadresComunitarias { get; set; }
        public Usuario()
        {
            MadresComunitarias = new List<MadreComunitaria>();
        }
        public ICollection<Nino> Ninos { get; set; }
    }
}
