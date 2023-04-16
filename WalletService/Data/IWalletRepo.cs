using WalletServices.Models;

namespace WalletServices.Data
{
    public interface IWalletRepo
    {
        IEnumerable<Wallet> GetAllWallet();
        // Task<Wallet> GetById(int id);
        Task<Wallet> GetByName(string name);
        Task TopupWallet(Wallet wallet);
        Task OrderWallet(string name, Wallet wallet);
        bool SaveChanges();
    }
}