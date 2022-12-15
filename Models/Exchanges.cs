using Binance.Spot;

namespace TORCHAIN.Models
{
    #region Binance
    public class BinancePrice
    {
        public int Mins { get; set; }
        public float Price { get; set; }
    }
    #endregion
    #region Zonda
    public class First
    {
        public string currency { get; set; }
        public string minOffer { get; set; }
        public int scale { get; set; }
    }

    public class MarketZonda
    {
        public string code { get; set; }
        public First first { get; set; }
        public Second second { get; set; }
        public int amountPrecision { get; set; }
        public int pricePrecision { get; set; }
        public int ratePrecision { get; set; }
    }

    public class ZondaPrice
    {
        public string status { get; set; }
        public Ticker ticker { get; set; }
    }

    public class Second
    {
        public string currency { get; set; }
        public string minOffer { get; set; }
        public int scale { get; set; }
    }

    public class Ticker
    {
        public MarketZonda market { get; set; }
        public string time { get; set; }
        public string highestBid { get; set; }
        public string lowestAsk { get; set; }
        public string rate { get; set; }
        public string previousRate { get; set; }
    }
    #endregion
    #region Bitrue
    public class BitruePrice
    {
        public string symbol { get; set; }
        public string price { get; set; }
    }
    #endregion
}
