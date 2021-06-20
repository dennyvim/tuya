using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tuya.Pagos.Domain.Entities
{

    [Table("Tbl_Eventos")]
    public class Evento
    {
        public Evento()
        {
        }
        [Key]
        public int Id { get; set; }

    }
}
