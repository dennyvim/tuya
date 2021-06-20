using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tuya.Pagos.Domain.Entities
{
    [Table("Tbl_Transacciones")]
    public class Transaccion
    {
        public Transaccion()
        {
        }
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
        public int IdUsuario { get; set; }

    }
}
