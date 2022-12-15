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
    #region Gate
    public class GatePrice
    {
        public string? currency_pair { get; set; }
        public string? last { get; set; }
        public string? lowest_ask { get; set; }
        public string? highest_bid { get; set; }
        public string? change_percentage { get; set; }
        public string? base_volume { get; set; }
        public string? quote_volume { get; set; }
        public string? high_24h { get; set; }
        public string? low_24h { get; set; }
    }

    public class Gate
    {
        public List<GatePrice>? Details { get; set; }
    }
    #endregion

    #region Kucoin
    public class KucoinDetails
    {
        public long time { get; set; }
        public string sequence { get; set; }
        public string price { get; set; }
        public string size { get; set; }
        public string bestBid { get; set; }
        public string bestBidSize { get; set; }
        public string bestAsk { get; set; }
        public string bestAskSize { get; set; }
    }

    public class KucoinPrice
    {
        public string code { get; set; }
        public KucoinDetails data { get; set; }
    }
    #endregion
}
