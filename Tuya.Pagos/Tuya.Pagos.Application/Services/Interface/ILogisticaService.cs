using System;
using System.Threading.Tasks;
using Tuya.Pagos.Application.DTO.Services;

namespace Tuya.Pagos.Application.Services.Interface
{
    public interface ILogisticaService
    {
        Task<ResultadoEventoDto> CrearEvento(ResultadoTransaccionDto transaccion);
    }
}
