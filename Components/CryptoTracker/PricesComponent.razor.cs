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
            {"Zonda","0" }
        };
        public string BinancePrice { get; set; } 
        public string ZondaPrice { get; set; } 
        protected async override Task OnInitializedAsync()
        {

            #region BinanceAPI

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

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.InnerException?.Message ?? exception.Message);
                }
            #endregion

        }
        private async void PriceCheck()
        {
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


        }
    }
}
