using System;
using System.Collections;
using System.Collections.Generic;
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
        [Column("Id")]
        public int Id { get; set; }

        [Column("Fecha")]
        public DateTime Fecha { get; set; }

        [Column("Total")]
        public float Total { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<TransaccionDetalle> TransaccionDetalles { get; set; }
        public ICollection<Evento> Eventos { get; set; }


    }
}
