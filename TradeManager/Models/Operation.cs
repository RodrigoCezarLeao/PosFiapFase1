namespace TradeManager.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public decimal Call { get; set; }
        public decimal Profit { get; set; }
        public DateTime Timestamp { get; set; }

        public decimal Payout() 
        {
            if (this.Profit > 0)
                return this.Profit / this.Call;
            else
                return 0;
        }

    }
}
