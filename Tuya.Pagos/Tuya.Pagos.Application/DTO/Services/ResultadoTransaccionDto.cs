using System;
using System.Collections.Generic;

namespace Tuya.Pagos.Application.DTO.Services
{
    public class ResultadoTransaccionDto
    {
        public ResultadoTransaccionDto()
        {
        }

        public int IdTransaccion { get; set; }
        public List<ProductosDto> Productos { get; set; }
        public int UsuarioId { get; set; }
        public float TotalCompra { get; set; }


    }
}
