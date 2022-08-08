using System;

namespace CakeCompany.IServices
{
    public interface IPaymentProvider<T,O>
    {
        public T Process(O order);
    }
}
