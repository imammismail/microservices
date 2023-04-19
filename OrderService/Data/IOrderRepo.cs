using OrderServices.Models;

namespace OrderServices.Data
{
    public interface IOrderRepo
    {
        IEnumerable<Order> GetAllOrder();
        Task CreateOrder(Order order);

        // Task<Order> GetByName(string name);
        // Task TopupWallet(Wallet wallet);
        // Task OrderWallet(string name, Wallet wallet);
        bool SaveChanges();
    }
}