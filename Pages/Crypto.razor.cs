using System.Net.Http.Headers;
using System.Xml.Linq;

using Binance.Spot;

using Microsoft.Extensions.Hosting;

using Newtonsoft.Json;

using TORCHAIN.Models;

namespace TORCHAIN.Pages
{
    public partial class Crypto
    {
        private static HttpClient _httpClient = new HttpClient();
        public List<string> Lista = new List<string>();

        protected async override Task OnInitializedAsync()
        {
            #region BinanceAPI
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
                Console.WriteLine(result);
                Console.WriteLine(JsonConvert.DeserializeObject(result));
                BinancePrice? Token = JsonConvert.DeserializeObject<BinancePrice>(result);
                Lista.Add(Token!.Price.ToString());
            }
            #endregion
        }
    }
}
