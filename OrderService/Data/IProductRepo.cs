using System;
using OrderServices.Models;
using System.Threading.Tasks;
namespace OrderServices.Data
{
    public interface IProductRepo
    {
        Task CreateProduct();
        IEnumerable<Product> GetAllProduct();
        // Task<Wallet> GetById(int id);
        // Task<Wallet> GetByName(string name);
        // Task TopupWallet(Wallet wallet);
        // Task OrderWallet(string name, Wallet wallet);
        bool SaveChanges();
    }
}