using System;

namespace CakeCompany.IServices;

public interface IOrderProvider<T,P>
{
    public  T[] GetLatestOrders();

    public T[] CheckIfAnyOrdersPlaced(T[] orders);


    public P[] ExecuteOrder();
}

