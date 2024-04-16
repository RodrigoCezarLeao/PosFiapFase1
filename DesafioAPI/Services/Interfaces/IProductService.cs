using DesafioAPI.Models;

namespace DesafioAPI.Services.Interfaces
{
    public interface IProductService
    {
        public bool isProductValid(Product product);
        public bool InsertProduct(Product product);
        public Product? GetProductById(Guid id);
        public List<Product> GetAllProducts();
        public bool DeleteProduct(Guid id);
        public bool DeleteAllProducts();
    }
}
