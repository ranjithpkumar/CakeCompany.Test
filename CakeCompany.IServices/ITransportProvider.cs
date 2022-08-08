using System;

using System.Collections.Generic;

namespace CakeCompany.IServices
{
   public interface ITransportProvider<T>
    {
      
        public ITransport<T> CheckForAvailability(List<T> products);

        public bool Dispatch(List<T> products);
    }
}
