using CakeCompany.IServices;
using CakeCompany.Services.FactoryPattern;
using CakeCompany.Services.Models;

namespace CakeCompany.Services.Provider;

public class TransportProvider : ITransportProvider<Product>
{
    public const string VAN = "Van";
    public const string TRUCK = "Truck";
    public const string SHIP = "Ship";
    ITransport<Product> _transport;


    public TransportProvider(ITransport<Product> transport)
    {
        _transport = transport ?? throw new ArgumentNullException(nameof(transport));
    }


    public ITransport<Product> CheckForAvailability(List<Product> products)
    {
        return GetTransportMode(products);
    }

    public bool Dispatch(List<Product> products)
    {
        _transport = CheckForAvailability(products);
        return _transport.Deliver(products);
    }

    private ITransport<Product> GetTransportMode(List<Product> products)
    {
        if (products.Sum(p => p.Quantity) < 1000)
        {
            return TransportFactory.GetTranport(VAN);
        }

        else if (products.Sum(p => p.Quantity) > 1000 && products.Sum(p => p.Quantity) < 5000)
        {
            return TransportFactory.GetTranport(TRUCK);
        }

        return TransportFactory.GetTranport(SHIP);
    }

}
