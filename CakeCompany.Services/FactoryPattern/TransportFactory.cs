using CakeCompany.IServices;
using CakeCompany.Services.Models;
using CakeCompany.Services.Models.Transport;
using CakeCompany.Services.Provider;

namespace CakeCompany.Services.FactoryPattern
{
    public class TransportFactory
    {
        public static ITransport<Product> GetTranport(string transportMode)
        => transportMode switch
        {
            TransportProvider.VAN =>  new Van(),
            TransportProvider.SHIP => new Ship(),
            TransportProvider.TRUCK => new Truck(),
            _ => throw new ArgumentOutOfRangeException(nameof(transportMode), $"Not transport Mode value: {transportMode}")
        };
    }
}
