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
        public int Id { get; set; }
    }
}
