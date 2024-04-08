using PosAluraFase1.DbWorker.Interfaces;
using PosAluraFase1.Models;

namespace PosAluraFase1.DbWorker.Repository
{
    public class AssetRepository: IAssetRepository
    {
        public Guid RepositoryId { get; set; }
        public List<Asset> Assets { get; set; }

        public AssetRepository() {
            this.RepositoryId = Guid.NewGuid();
            this.Assets = new List<Asset>();
        }

        public bool CreateAsset(string Ticker)
        {
            try
            {
                if (this.Assets.Any(x => x.Ticker.Equals(Ticker)))
                    throw new Exception("Ticker already exists and must be unique!");

                var asset = new Asset();
                asset.Ticker = Ticker;
                asset.Id = Guid.NewGuid();

                this.Assets.Add(asset);
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        public Asset GetAsset(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Asset GetAssets()
        {
            throw new NotImplementedException();
        }
    }
}
