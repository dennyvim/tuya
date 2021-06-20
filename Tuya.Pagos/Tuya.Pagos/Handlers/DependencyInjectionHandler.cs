using System;
using Microsoft.Extensions.DependencyInjection;
using Tuya.Pagos.Application.Services;
using Tuya.Pagos.Application.Services.Interface;

namespace Tuya.Pagos.WebApi.Handlers
{
    public class DependencyInjectionHandler
    {
        public DependencyInjectionHandler()
        {
        }

        public static void DependencyInjectionConfig(IServiceCollection services)
        {
            // Application
            services.AddTransient<IFacturacionService, FacturacionService>();
        }
    }
}
