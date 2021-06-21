using System;
using Tuya.Pagos.Application.DTO.Services;

namespace Tuya.Pagos.Application.Responses
{
    public class ResultadoPagos
    {
        public ResultadoPagos()
        {
        }

        public ResultadoEventoDto Evento { get; set; }
        public ResultadoTransaccionDto Transaccion { get; set; }

    }
}
