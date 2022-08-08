using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.IServices
{
    public interface ICancellationProvider<T>
    {
        public List<T> AddCancelledOrder(T orders);
    }
}
