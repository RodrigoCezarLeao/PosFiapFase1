using PosAluraFase1.DbWorker.Repository;

namespace PosAluraFase1.Repository
{
    public class DbWorker : IDbWorker
    {
        public AssetRepository AssetRepository { get; set; }
        public DbWorker() 
        {
            this.init();
        }
        public void init()
        {
            this.AssetRepository = new AssetRepository();
        }
    }
}
