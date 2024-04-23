using TradeManager.Models;

namespace TradeManager.Repositories.Interfaces
{
    public interface IOperationRepository
    {
        public List<Operation> GetAllOperations();
        public List<Operation> GetAllOperationsNpgsql();
        public List<Operation> GetAllOperationsDapper();
        public bool CreateOperation(Operation operation);
        public bool CreateOperationNpgsql(Operation operation);
        public bool CreateOperationDapper(Operation operation);
    }
}
