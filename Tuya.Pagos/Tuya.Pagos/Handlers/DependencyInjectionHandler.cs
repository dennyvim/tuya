using Microsoft.Extensions.DependencyInjection;
using Tuya.Pagos.Application.Services.Facturacion;
using Tuya.Pagos.Application.Services.Interface;
using Tuya.Pagos.Application.Services.Logistica;
using Tuya.Pagos.Data.Repositories;
using Tuya.Pagos.Data.UnitOfWork;
using Tuya.Pagos.Domain.Repository;

namespace Tuya.Pagos.WebApi.Handlers
{
    public class DependencyInjectionHandler
    {
        public DependencyInjectionHandler()
        {
        }

        public static void DependencyInjectionConfig(IServiceCollection services)
        {
            services.AddScoped<PagosUnitOfWork, PagosUnitOfWork>();

            // Application
            services.AddTransient<IFacturacionService, FacturacionService>();
            services.AddTransient<ILogisticaService, LogisticaService>();

            // Infraestructura
            services.AddTransient<IPagosUnitOfWork, PagosUnitOfWork>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));


        }
    }
}
