using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PosAluraFase1.Repository;

namespace PosAluraFase1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        IDbWorker Db { get; set; }
        public AssetController([FromKeyedServices("banco_singleton")] IDbWorker dbWorker) 
        { 
            this.Db = dbWorker;
        }


        [HttpPost]
        public IActionResult CreateAsset([FromBody] string Ticker)
        {
            if (this.Db.AssetRepository.CreateAsset(Ticker))
                return Ok(Ticker);

            return BadRequest("Error in Asset creation!");

        }
    }
}
