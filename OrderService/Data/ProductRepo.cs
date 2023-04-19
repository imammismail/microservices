using OrderServices.Models;
using OrderServices.SyncDataServices;
using Microsoft.EntityFrameworkCore;

namespace OrderServices.Data
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;
        private readonly IProductDataClient _client;
        public ProductRepo(AppDbContext context, IProductDataClient client)
        {
            _context = context;
            _client = client;
        }
        public async Task CreateProduct()
        {
            var product = await _client.ReturnAllProduct();
            foreach (var prod in product)
            {
                _context.Add(new Product
                {
                    Id = prod.Id,
                    Name = prod.name,
                    Price = prod.price,
                    Stock = prod.stock
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

        public IEnumerable<Product> GetAllProduct()
        {
            return _context.Products.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}