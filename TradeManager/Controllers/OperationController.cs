using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeManager.Models;
using TradeManager.Repositories.Interfaces;

namespace TradeManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationRepository _operationRepository;
        public OperationController(IOperationRepository operationRepository) 
        { 
            _operationRepository = operationRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //var result = _operationRepository.GetAllOperations();
            //var result = _operationRepository.GetAllOperationsNpgsql();
            var result = _operationRepository.GetAllOperationsDapper();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(Operation operation)
        {
            //var result = _operationRepository.CreateOperation(operation);
            //var result = _operationRepository.CreateOperationNpgsql(operation);
            var result = _operationRepository.CreateOperationDapper(operation);
            return Ok(result);
        }
    }
}
