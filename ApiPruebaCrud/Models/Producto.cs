using System.ComponentModel.DataAnnotations;

namespace ApiPruebaCrud.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }
    }
}
