using System;
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
    }
}
