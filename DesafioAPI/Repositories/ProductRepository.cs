using DesafioAPI.Models;
using DesafioAPI.Repositories.Interfaces;
using DesafioAPI.Services;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DesafioAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> Products = new List<Product>();
        private readonly SQLiteConnection _conn;

        public ProductRepository(SQLiteConnection con) 
        { 
            _conn = con;
        }

        public bool DeleteAllProducts()
        {
            try
            {
                this.Products.Clear();

                if (this.Products.Any()) throw new Exception("Nenhum produto cadastrado!");

                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty)) throw new Exception("Id passado é vazio!");

                var product = this.Products.FirstOrDefault(p => p.Id.Equals(id));

                if (product == null) throw new Exception("O produto não foi encontrado!");

                this.Products.Remove(product);

                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            var result = new List<Product>();

            var cmd = this._conn.CreateCommand();
            cmd.CommandText = $"""
                    SELECT * FROM product;
                """;

            using (var reader = cmd.ExecuteReader()) 
            {
                while (reader.Read())
                {
                    result.Add(new Product()
                    {
                        Id = Guid.Parse(reader["id"].ToString()),
                        Name = reader["name"].ToString(),
                        Description= reader["description"].ToString(),
                        Value= (double) reader["value"]
                    });
                }
            }
            
            return result;
        }

        public Product? GetProductById(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty)) throw new Exception("Id passado é vazio!");

                var product = this.Products.FirstOrDefault(p => p.Id.Equals(id));

                if (product == null) throw new Exception("O produto não foi encontrado!");

                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public bool InsertProduct(Product product)
        {
            try
            {
                var cmd = this._conn.CreateCommand();
                cmd.CommandText = $"""
                    INSERT INTO product (id, name, description, value) values
                    ('{product.Id}', '{product.Name}', '{product.Description}', {product.Value});
                """;

                using (var reader = cmd.ExecuteReader()) { }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


    }
}
