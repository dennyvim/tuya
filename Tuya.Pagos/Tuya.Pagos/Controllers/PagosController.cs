using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tuya.Pagos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        public PagosController()
        {
        }


        [HttpPost(Name = "Pagar")]
        public void RealizarPago()
        {


        }

    }


}
