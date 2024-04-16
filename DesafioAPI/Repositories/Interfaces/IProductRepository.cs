using DesafioAPI.Models;

namespace DesafioAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public bool InsertProduct(Product product);
        public Product? GetProductById(Guid id);
        public List<Product> GetAllProducts();
        public bool DeleteProduct(Guid id);
        public bool DeleteAllProducts();
    }
}
