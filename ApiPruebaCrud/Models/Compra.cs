using System.ComponentModel.DataAnnotations;

namespace ApiPruebaCrud.Models
{
    public class Compra
    {
        [Key]
        public int CompraId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaCompra { get; set; }

        [Required]
        public int Cantidad { get; set; }
    }
}
