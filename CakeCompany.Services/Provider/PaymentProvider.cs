using CakeCompany.Services.Models;
using CakeCompany.IServices;
using Microsoft.Extensions.Logging;

namespace CakeCompany.Services.Provider;

public class PaymentProvider: IPaymentProvider<PaymentIn,Order>
{ 
    readonly ICancellationProvider<Order> _cancellationProvider;
    public PaymentProvider( ICancellationProvider<Order> cancellationProvider)
    {
        _cancellationProvider = cancellationProvider ?? throw new ArgumentNullException(nameof(cancellationProvider));
    }
    public PaymentIn Process(Order order)
    {
        PaymentIn paymentIn = CheckClientCreditLimit(order);
        if (!paymentIn.IsSuccessful)
            _cancellationProvider.AddCancelledOrder(order);
        return paymentIn;
   }

    PaymentIn CheckClientCreditLimit(Order order)
        => new PaymentIn
        {
            HasCreditLimit = order.ClientName.Contains("Important") ? false : true,
            IsSuccessful = true
        };
    
}