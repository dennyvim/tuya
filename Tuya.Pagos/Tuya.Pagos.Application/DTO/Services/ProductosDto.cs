using System;
using System.ComponentModel.DataAnnotations;

namespace Tuya.Pagos.Application.DTO.Services
{
    public class ProductosDto
    {
        public ProductosDto()
        {
        }
        [Required]
        public int ProductId { get; set; }
        public float Price { get; set; }
    }
}
