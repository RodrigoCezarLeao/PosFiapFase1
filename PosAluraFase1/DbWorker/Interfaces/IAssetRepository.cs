using PosAluraFase1.Models;

namespace PosAluraFase1.DbWorker.Interfaces
{
    public interface IAssetRepository
    {
        public bool CreateAsset(string Ticker);
        public Asset GetAssets();
        public Asset GetAsset(Guid Id);
    }
}
