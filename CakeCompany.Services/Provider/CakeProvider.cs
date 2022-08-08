using CakeCompany.IServices;
using CakeCompany.Services.Models;

namespace CakeCompany.Services.Provider;

public class CakeProvider : ICakeProvider<Order, Product>
{



    readonly IPaymentProvider<PaymentIn, Order> _paymentProvider;

    readonly ICancellationProvider<Order> _cancellationProvider;
    public CakeProvider(ICancellationProvider<Order> cancellationProvider, IPaymentProvider<PaymentIn, Order> paymentProvider, ITransportProvider<Product> transportProvider)
    {
        _cancellationProvider = cancellationProvider ?? throw new ArgumentNullException(nameof(cancellationProvider));
        _paymentProvider = paymentProvider ?? throw new ArgumentNullException(nameof(paymentProvider));
    }

    public DateTime CheckestimatedBakeTime(Order order)
      => (order.Name == Cake.Chocolate) ? AddOrderMinutes(30) : (order.Name == Cake.RedVelvet)
            ? AddOrderMinutes(60) : AddOrderMinutes(15);
    DateTime AddOrderMinutes(int minutes) => DateTime.Now.Add(TimeSpan.FromMinutes(minutes));

    public Product Bake(Order order)
        => new()
        {
            Cake = order.Name,
            Id = new Guid(),
            Quantity = order.Quantity
        };

    public Product[] Process(Order[] orders)
    {
        var products = new List<Product>();
        foreach (var order in orders)
        {
            if (CheckestimatedBakeTime(order) > order.EstimatedDeliveryTime)
            {
                _cancellationProvider.AddCancelledOrder(order);
                continue;
            }
            if (!_paymentProvider.Process(order).IsSuccessful)
                continue;
            products.Add(Bake(order));

        }
        return products.ToArray();
    }


}