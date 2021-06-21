using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tuya.Pagos.Domain.Entities
{
    [Table("Tbl_TxDetalles")]
    public class TransaccionDetalle
    {
        public TransaccionDetalle()
        {
        }
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        [ForeignKey("Transaccion")]
        public int TransaccionId { get; set; }
        public Transaccion Transaccion { get; set; }
    }
}
