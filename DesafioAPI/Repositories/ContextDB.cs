
using DesafioAPI.Repositories.Interfaces;
using System.Data.Common;
using System.Data.SQLite;

namespace DesafioAPI.Repositories
{
    public class ContextDB : IContextDB
    {
        public IProductRepository productRepository;
        private SQLiteConnection connection;
        public ContextDB(IServiceProvider serviceProvider)
        {
            var createDB = false;
            var dbPath = Path.Combine(Environment.CurrentDirectory, "db.sql");
            if (!File.Exists(dbPath))
            {
                try
                {
                    SQLiteConnection.CreateFile(dbPath);
                    createDB = true;
                }catch (Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            this.connection = new SQLiteConnection($"Data Source={dbPath};");
            this.connection.Open();

            if (createDB)
            {
                var cmd = this.connection.CreateCommand();
                cmd.CommandText = """
                    CREATE TABLE product (
                        id TEXT PRIMARY KEY,
                        name TEXT NOT NULL,
                        description TEXT NOT NULL,
                        value REAL NOT NULL
                    );
                """;

                using (var reader = cmd.ExecuteReader()){}
            }


            // init repositories
            this.productRepository = new ProductRepository(this.connection);
        }

        public IProductRepository ProductRepository() { return this.productRepository; }
    }
}
