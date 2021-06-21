using System;
using System.ComponentModel.DataAnnotations;

namespace Tuya.Pagos.Application.DTO.Services
{
    public class ProductoDto
    {
        public ProductoDto()
        {
        }

        public int Id { get; set; }
        [Required]
        public string NombreProducto { get; set; }
        [Required]
        public float Precio { get; set; }
    }
}
