using CakeCompany.IServices;
using CakeCompany.Services.Models;

namespace CakeCompany.Services.Provider
{
    public class CancellationProvider : ICancellationProvider<Order>
    {
        List<Order> cancelledOrders = new List<Order>();

        public List<Order> AddCancelledOrder(Order orders)
        {
            cancelledOrders.Add(orders);
            return cancelledOrders;
        }
    }
}
