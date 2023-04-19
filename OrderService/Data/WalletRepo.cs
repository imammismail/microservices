using OrderServices.Models;
using OrderServices.SyncDataServices;
using Microsoft.EntityFrameworkCore;

namespace OrderServices.Data
{
    public class WalletRepo : IWalletRepo
    {
        private readonly AppDbContext _context;
        private readonly IWalletDataClient _client;
        public WalletRepo(AppDbContext context, IWalletDataClient client)
        {
            _context = context;
            _client = client;
        }
        public async Task CreateWallet()
        {
            var product = await _client.ReturnAllWallet();
            foreach (var prod in product)
            {
                Console.WriteLine("insert wallet to the database");
                _context.Add(new Wallet
                {
                    WalletId = prod.id,
                    Username = prod.userName,
                    Cash = prod.cash
                });
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not save changes to the database: {ex.Message}");
            }
        }

        public IEnumerable<Wallet> GetAllWallet()
        {
            return _context.Wallets.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}