using CakeCompany.IServices;
using CakeCompany.Services.Models;
using Microsoft.Extensions.Logging;

namespace CakeCompany.Services.Provider;
public class ShipmentProvider : IShipmentProvider
{
    readonly ITransportProvider<Product> _transportProvider = null;
    readonly IOrderProvider<Order, Product> _orderProvider;
    readonly ILogger<ShipmentProvider> _logger;

    public ShipmentProvider(ILogger<ShipmentProvider> logger, IOrderProvider<Order, Product> orderProvider, ITransportProvider<Product> transportProvider)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _orderProvider = orderProvider ?? throw new ArgumentNullException(nameof(orderProvider));
        _transportProvider = transportProvider;
    }
    public bool GetShipment()
    {
        bool disPatchStatus = false;
        var products = _orderProvider.ExecuteOrder();
        if (products.Any())
        {
            if (_transportProvider.Dispatch(products.ToList()))
            {
                _logger.LogInformation("Products have been dispatched successfully");
                disPatchStatus = true;
            }
            else
            {
                _logger.LogInformation("Products have not been dispatched");
                disPatchStatus = false;
            }
        }
        else
        {
            _logger.LogInformation("The order has been canceled");
            disPatchStatus = false;
        }
        return disPatchStatus;
    }

}

