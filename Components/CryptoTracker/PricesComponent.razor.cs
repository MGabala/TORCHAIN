using Binance.Common;
using Binance.Spot;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TORCHAIN.Models;

namespace TORCHAIN.Components.CryptoTracker
{
    public partial class PricesComponent
    {
       private static HttpClient _httpClient = new HttpClient();
        public Dictionary<string, string> Lista = new Dictionary<string, string>()
        {
            {"Binance","0" },
            {"Zonda","0" },
            {"Bitrue","0" }
        };
        public string BinancePrice { get; set; } 
        public string ZondaPrice { get; set; } 
        public string BitruePrice { get; set; } 
        protected async override Task OnInitializedAsync()
        {
            await PriceCheck();
        }
        private async Task PriceCheck()
        {
            #region BinanceAPI
            try
            {
                using (_httpClient = new HttpClient())
                {
                    _httpClient.BaseAddress = new Uri("https://testnet.binance.vision");
                    _httpClient.Timeout = new TimeSpan(0, 0, 5);
                    _httpClient.DefaultRequestHeaders.Clear();
                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    _httpClient.DefaultRequestHeaders.Add("X-MBX-APIKEY", Environment.GetEnvironmentVariable("APIKEY"));
                    _httpClient.DefaultRequestHeaders.Add("SecretKey", Environment.GetEnvironmentVariable("SECRETKEY"));
                    var symbol = "BTCBUSD";
                    var market = new Market(_httpClient);
                    var result = await market.CurrentAveragePrice(symbol);
                    BinancePrice? binancePrice = JsonConvert.DeserializeObject<BinancePrice>(result);
                    Lista["Binance"] = binancePrice!.Price.ToString();
                    BinancePrice = binancePrice!.Price.ToString();
                }
            }
            catch (BinanceClientException binanceException)
            {
                Console.WriteLine(binanceException.InnerException?.Message ?? binanceException.Message);
            }
            #endregion
            #region Zonda
            try
            {
                using (_httpClient = new HttpClient())
                {
                    _httpClient.BaseAddress = new Uri("https://api.zonda.exchange");
                    _httpClient.Timeout = new TimeSpan(0, 0, 5);
                    _httpClient.DefaultRequestHeaders.Clear();
                    var response = await _httpClient.GetAsync("/rest/trading/ticker/BTC-USDT");
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                    ZondaPrice? zondaPrice = JsonConvert.DeserializeObject<ZondaPrice>(body);
                    Lista["Zonda"] = zondaPrice!.ticker.rate;
                    ZondaPrice = zondaPrice!.ticker.rate;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.InnerException?.Message ?? exception.Message);
            }
            #endregion

            #region Bitrue
            try
            {
                using (_httpClient = new HttpClient())
                {
                    _httpClient.BaseAddress = new Uri("https://openapi.bitrue.com");
                    _httpClient.Timeout = new TimeSpan(0, 0, 5);
                    _httpClient.DefaultRequestHeaders.Clear();
                    var response = await _httpClient.GetAsync("/api/v1/ticker/price?symbol=btcusdt");
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                    BitruePrice? bitruePrice = JsonConvert.DeserializeObject<BitruePrice>(body);
                    BitruePrice = bitruePrice!.price;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.InnerException?.Message ?? exception.Message);
            }
            #endregion


        }
    }
}
