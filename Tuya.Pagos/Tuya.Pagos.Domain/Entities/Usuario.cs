using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tuya.Pagos.Domain.Entities
{
    [Table("Tbl_Usuarios")]
    public class Usuario
    {
        public Usuario()
        {
        }
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nombres")]
        public string Nombres { get; set; }

        [Column("Apellidos")]
        public string Apellidos { get; set; }

        [Column("Direccion")]
        public string Direccion { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Cedula")]
        public int Cedula { get; set; }

        public ICollection<Transaccion> Transacciones { get; set; }
    }
}
