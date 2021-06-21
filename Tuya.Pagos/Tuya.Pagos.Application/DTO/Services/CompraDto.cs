using System;
using System.Collections.Generic;

namespace Tuya.Pagos.Application.DTO.Services
{
    public class CompraDto
    {
        public CompraDto()
        {
        }

        public List<ProductosDto> Productos { get; set; }
        public int UserId { get; set; }

    }
}
