using System.ComponentModel.DataAnnotations;

namespace ApiPruebaCrud.Models
{
    public class Usuario
    {
        [Key]
        public int UserId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        [Required]
        public string Clave { get; set; }
    }
}
