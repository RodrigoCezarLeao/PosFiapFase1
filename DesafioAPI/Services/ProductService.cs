using DesafioAPI.Models;
using DesafioAPI.Repositories.Interfaces;
using DesafioAPI.Services.Interfaces;

namespace DesafioAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IContextDB _contextDB;
        public ProductService(IContextDB contextDB)
        {
            _contextDB = contextDB;
        }
        public bool isProductValid(Product product)
        {
            try
            {
                if (product.Name.Equals(String.Empty)) throw new Exception("Nenhum nome foi definido para o produto!");
                if (product.Description.Equals(String.Empty)) throw new Exception("O produto precisa ter uma descrição!");
                if (product.Value <= 0) throw new Exception("Um valor real de custo precisa ser definido para o produto!");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool DeleteAllProducts()
        {
            return _contextDB.ProductRepository().DeleteAllProducts();
        }

        public bool DeleteProduct(Guid id)
        {
            return _contextDB.ProductRepository().DeleteProduct(id);
        }

        public List<Product> GetAllProducts()
        {
            return _contextDB.ProductRepository().GetAllProducts();
        }

        public Product? GetProductById(Guid id)
        {
            return _contextDB.ProductRepository().GetProductById(id);
        }

        public bool InsertProduct(Product product)
        {
            if (!this.isProductValid(product))
                return false;

            return _contextDB.ProductRepository().InsertProduct(product);
        }

        



    }
}
