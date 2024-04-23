using Dapper;
using Npgsql;
using System.Data;
using TradeManager.Models;
using TradeManager.Repositories.Interfaces;

namespace TradeManager.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly IDbConnection _context;
        public OperationRepository(IDbConnection context)
        {
            _context = context;
            _context.Open();
        }

        public List<Operation> GetAllOperations()
        {
            List<Operation> result = new List<Operation>();

            var cmd = _context.CreateCommand();
            cmd.CommandText = """
                SELECT *
                FROM trade;
            """;

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {                
                var op = new Operation();
                op.Id = (int) reader["id"];
                op.Ticker = (string) reader["ticker"];
                op.Call = (decimal) reader["call"];
                op.Profit = (decimal) reader["profit"];
                op.Timestamp = (DateTime) reader["timestamp"];
                result.Add(op);
            }
            

            return result;
        }

        public bool CreateOperation(Operation operation)
        {
            var cmd = _context.CreateCommand();
            cmd.CommandText = """
                INSERT INTO trade (ticker, call, profit, timestamp) VALUES
                (@ticker, @call, @profit, @timestamp);
            """;

            var parameter1 = cmd.CreateParameter();
            parameter1.ParameterName = "@ticker";
            parameter1.Value = operation.Ticker;
            cmd.Parameters.Add(parameter1);
            
            var parameter2 = cmd.CreateParameter();
            parameter2.ParameterName = "@call";
            parameter2.Value = operation.Call;
            cmd.Parameters.Add(parameter2);
            
            var parameter3 = cmd.CreateParameter();
            parameter3.ParameterName = "@profit";
            parameter3.Value = operation.Profit;
            cmd.Parameters.Add(parameter3);
            
            var parameter4 = cmd.CreateParameter();
            parameter4.ParameterName = "@timestamp";
            parameter4.Value = operation.Timestamp;
            cmd.Parameters.Add(parameter4);

            var result = cmd.ExecuteNonQuery();

            return result > 0;
        }

        public List<Operation> GetAllOperationsNpgsql()
        {
            List<Operation> result = new List<Operation>();

            NpgsqlConnection con = (NpgsqlConnection) _context;
            var cmd = new NpgsqlCommand("SELECT * FROM trade;", con);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var op = new Operation();
                op.Id = (int)reader["id"];
                op.Ticker = (string)reader["ticker"];
                op.Call = (decimal)reader["call"];
                op.Profit = (decimal)reader["profit"];
                op.Timestamp = (DateTime)reader["timestamp"];
                result.Add(op);
            }

            return result;
        }

        public bool CreateOperationNpgsql(Operation operation)
        {
            NpgsqlConnection con = (NpgsqlConnection)_context;
            var cmd = new NpgsqlCommand("""
                INSERT INTO trade (ticker, call, profit, timestamp) VALUES
                    (@ticker, @call, @profit, @timestamp);
            """, con);

            cmd.Parameters.AddWithValue("@ticker", operation.Ticker);
            cmd.Parameters.AddWithValue("@call", operation.Call);
            cmd.Parameters.AddWithValue("profit", operation.Profit);
            cmd.Parameters.AddWithValue("@timestamp", operation.Timestamp);
            

            var result = cmd.ExecuteNonQuery();

            return result > 0;
        }

        public List<Operation> GetAllOperationsDapper()
        {
            var sql = "SELECT * FROM trade;";
            var operations = _context.Query<Operation>(sql).ToList();
            return operations;
        }

        public bool CreateOperationDapper(Operation operation)
        {
            var sql = """
                INSERT INTO trade (ticker, call, profit, timestamp) VALUES
                    (@ticker, @call, @profit, @timestamp);
            """;

            var parameters = new { 
                Ticker = operation.Ticker, 
                Call = operation.Call,
                Profit = operation.Profit,
                Timestamp = operation.Timestamp,
            };

            var result = _context.Execute(sql, parameters);
            return result > 0;
        }

    }
}
