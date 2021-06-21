using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tuya.Pagos.Utils.Enum;

namespace Tuya.Pagos.Domain.Entities
{

    [Table("Tbl_Eventos")]
    public class Evento
    {
        public Evento()
        {
        }
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        public Eventos TipoEvento { get; set; }
        public DateTime UltimaActualizacion { get; set; }


        [ForeignKey("Transaccion")]
        public int TransaccionId { get; set; }
        public Transaccion Transaccion { get; set; }


    }
}
