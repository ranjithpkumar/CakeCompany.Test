using CakeCompany.IServices;

namespace CakeCompany.Services.Models.Transport
{
    public abstract class BaseTransport : ITransport<Product>
    {
        public virtual bool Deliver(List<Product> products) => true;

    }
}
