using System;
using System.ComponentModel.DataAnnotations;

namespace Tuya.Pagos.Domain.Entities
{
    public class Pedido
    {
        public Pedido()
        {
        }
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
