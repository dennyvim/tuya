using System;
using System.Threading.Tasks;
using Tuya.Pagos.Application.DTO.Services;
using Tuya.Pagos.Domain.Entities;

namespace Tuya.Pagos.Application.Services.Interface
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> CrearUsuario(UsuarioDto usuario);

    }
}
