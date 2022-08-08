using CakeCompany.IServices;
using CakeCompany.Services.Models;
using CakeCompany.Services.Models.Transport;
using CakeCompany.Services.Provider;
using Microsoft.Extensions.DependencyInjection;

namespace CakeCompany.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICakeProvider<Order, Product>, CakeProvider>();
            services.AddTransient<IOrderProvider<Order,Product>, OrderProvider>();
            services.AddTransient<IPaymentProvider<PaymentIn, Order>, PaymentProvider >();
            services.AddTransient<IShipmentProvider, ShipmentProvider>();
            services.AddTransient<ICancellationProvider<Order>, CancellationProvider>();
            services.AddTransient<ITransportProvider<Product>, TransportProvider>();
            services.AddTransient<ITransport<Product>, Ship>();
            return services;
        }

    }
}