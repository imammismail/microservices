using ProductServices.Models;

namespace ProductServices.Data
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProduct();
        Task<Product> GetById(int id);
        Task<Product> GetByName(string name);
        void CreateProduct(Product product);
        Task Update(int id, Product product);
        Task DeleteProduct(int id);
        bool SaveChanges();
    }
}