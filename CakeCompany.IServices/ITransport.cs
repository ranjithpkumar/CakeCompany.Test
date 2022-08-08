using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.IServices
{
    public interface ITransport<T>
    {
        public bool Deliver(List<T> products);
       
    }
}
