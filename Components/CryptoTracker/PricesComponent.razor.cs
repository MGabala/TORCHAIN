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
        public string BinancePrice { get; set; } 
        public string ZondaPrice { get; set; } 
        public string BitruePrice { get; set; } 
        public string GatePrice { get; set; } 
        public string KucoinPrice { get; set; }
        protected async override Task OnInitializedAsync()
        {

            var timer = new System.Threading.Timer((_) =>
            {

                InvokeAsync(async () =>
                {
                    await PriceCheck();
                    StateHasChanged();
                    Console.WriteLine("Program works correctly.");
                });
            }, null, 0, 1000);
        }

        private async Task PriceCheck()
        {
            #region BinanceAPI
            try
            {
                using (_httpClient = new HttpClient())
                {
                    _httpClient.BaseAddress = new Uri("https://api.binance.com");
                    _httpClient.Timeout = new TimeSpan(0, 0, 5);
                    _httpClient.DefaultRequestHeaders.Clear();
                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    _httpClient.DefaultRequestHeaders.Add("X-MBX-APIKEY", Environment.GetEnvironmentVariable("APIKEY"));
                    _httpClient.DefaultRequestHeaders.Add("SecretKey", Environment.GetEnvironmentVariable("SECRETKEY"));
                    var symbol = "BTCBUSD";
                    var market = new Market(_httpClient);
                    var result = await market.SymbolPriceTicker(symbol);
                    BinancePrice? binancePrice = JsonConvert.DeserializeObject<BinancePrice>(result);
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
                    ZondaPrice? zondaPrice = JsonConvert.DeserializeObject<ZondaPrice>(body);
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
                    BitruePrice? bitruePrice = JsonConvert.DeserializeObject<BitruePrice>(body);
                    BitruePrice = bitruePrice!.price;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.InnerException?.Message ?? exception.Message);
            }
            #endregion

            #region Gate
            try
            {
                using (_httpClient = new HttpClient())
                {
                    _httpClient.BaseAddress = new Uri("https://api.gateio.ws");
                    _httpClient.Timeout = new TimeSpan(0, 0, 5);
                    _httpClient.DefaultRequestHeaders.Clear();
                    var response = await _httpClient.GetAsync("/api/v4/spot/tickers?currency_pair=BTC_USDT");
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    List<GatePrice>? gatePrice = JsonConvert.DeserializeObject<List<GatePrice>>(body);
                    GatePrice = gatePrice!.First().last;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.InnerException?.Message ?? exception.Message);
            }
            #endregion

            #region Kucoin
            try
            {
                using (_httpClient = new HttpClient())
                {
                    _httpClient.BaseAddress = new Uri("https://api.kucoin.com");
                    _httpClient.Timeout = new TimeSpan(0, 0, 5);
                    _httpClient.DefaultRequestHeaders.Clear();
                    var response = await _httpClient.GetAsync("/api/v1/market/orderbook/level1?symbol=BTC-USDT");
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    KucoinPrice? kucoinPrice = JsonConvert.DeserializeObject<KucoinPrice>(body);
                    KucoinPrice = kucoinPrice!.data.price;
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
