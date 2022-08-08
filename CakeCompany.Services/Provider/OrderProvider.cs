using CakeCompany.IServices;
using CakeCompany.Services.Models;

namespace CakeCompany.Services.Provider;

public class OrderProvider : IOrderProvider<Order, Product>
{

    readonly ICakeProvider<Order, Product> _cakeProvider;

    public OrderProvider(ICakeProvider<Order, Product> cakeProvider)
    {
        _cakeProvider = cakeProvider ?? throw new ArgumentNullException(nameof(cakeProvider));
    }
    public Order[] GetLatestOrders()
    {
        return new Order[]
        {
            new("CakeBox", DateTime.Now.AddHours(1), 1, Cake.Vanilla, 2500),
            new("CakeBox", DateTime.Now.AddHours(1), 1, Cake.Chocolate, 120.25),
            new("CakeBox", DateTime.Now, 1, Cake.RedVelvet, 120.25),
            new("ImportantCakeShop", DateTime.Now, 1, Cake.RedVelvet, 120.25)
        };
    }

    public Order[] CheckIfAnyOrdersPlaced(Order[] orders) => GetLatestOrders();

    public Product[] ExecuteOrder() { return _cakeProvider.Process(GetLatestOrders()); }

}


