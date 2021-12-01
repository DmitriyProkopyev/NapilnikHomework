public interface IPaymentSystem<T>
{
    T GetPaylink(Order order);
}
