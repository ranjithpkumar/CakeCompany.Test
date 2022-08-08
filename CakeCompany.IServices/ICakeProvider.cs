namespace CakeCompany.IServices
{
    public interface ICakeProvider<T,P>
    {
        public DateTime CheckestimatedBakeTime(T order);
        public P[] Process(T[] orders);
    }
}