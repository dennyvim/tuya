using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tuya.Pagos.Domain.Entities
{
    [Table("Tbl_Productos")]
    public class Producto
    {
        public Producto()
        {
        }
        [Key]
        public int Id { get; set; }

        [Column("NombreProducto")]
        public string NombreProducto { get; set; }

        [Column("Precio")]
        public float Precio { get; set; }

        public ICollection<TransaccionDetalle> TransaccionDetalles { get; set; }
    }
}
