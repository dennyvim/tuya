using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tuya.Pagos.Application.DTO.Services;
using Tuya.Pagos.Application.Services.Interface;

namespace Tuya.Pagos.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IFacturacionService _facturacionService;

        public UsuarioController(IFacturacionService facturacionService)
        {
            _facturacionService = facturacionService;
        }

        [HttpPost(Name = "CrearUsuario")]
        public void CrearUsuario(UsuarioDto usuario)
        {

        }
    }
}
