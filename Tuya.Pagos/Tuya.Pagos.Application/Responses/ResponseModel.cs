using System;
namespace Tuya.Pagos.Application.Responses
{
    public class ResponseModel<T> where T : class
    {
        public ResponseModel()
        {
        }
        public bool Exitoso { get; set; }
        public string Descripcion { get; set; }
        public T Resultado { get; set; }
    }
}
