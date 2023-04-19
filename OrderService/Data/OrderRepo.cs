using Microsoft.EntityFrameworkCore;
using OrderServices.Models;
using OrderServices.SyncDataServices;

namespace OrderServices.Data
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _context;
        private readonly IProductDataClient _productClient;
        private readonly IWalletDataClient _walletClient;
        public OrderRepo(AppDbContext context, IProductDataClient productClient, IWalletDataClient walletClient)
        {
            _context = context;
            _productClient = productClient;
            _walletClient = walletClient;
        }
        public IEnumerable<Order> GetAllOrder()
        {
            return _context.Orders.ToList();
        }

        public async Task CreateOrder(Order order)
        {
            try
            {
                if (order == null)
                {
                    throw new ArgumentNullException(nameof(order));
                }
                // var getProductName = await _productClient.GetProductByname(order.ProductName);
                var getProductName = await _context.Products.FirstOrDefaultAsync(p => p.Name == order.ProductName);
                // var getWalletName = await _walletClient.GetWalletByname(order.UserNameOrder);
                var getWalletName = await _context.Wallets.FirstOrDefaultAsync(p => p.Username == order.UserNameOrder);
                var totalPrice = getProductName.Price * order.Qty;
                Console.WriteLine($"ini total,{totalPrice}");
                if (getProductName == null)
                {
                    Console.WriteLine($"product not found");
                    throw new Exception("product not found");
                }
                if (getWalletName == null)
                {
                    Console.WriteLine($"wallet not found");
                    throw new Exception("name wallet not found");
                }
                if (getProductName.Stock < order.Qty)
                {
                    Console.WriteLine($"stok di produk kurang");
                    throw new Exception("stok produk kurang");
                }
                if (getWalletName.Cash < totalPrice)
                {
                    Console.WriteLine($"wallet cash kurang");
                    throw new Exception("wallet cash kurang");
                }
                _context.Orders.Add(order);
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not add platform to the database: {ex.Message}");
            }


        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}