using PosAluraFase1.DbWorker.Repository;

namespace PosAluraFase1.Repository
{
    public interface IDbWorker
    {
        public AssetRepository AssetRepository { get; set; }
        public void init();
    }
}
