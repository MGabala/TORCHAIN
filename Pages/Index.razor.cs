using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;

using System.Xml.Linq;

namespace TORCHAIN.Pages
{
    public partial class Index
    {
        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        public string? DataFromDifferentPage { get; set; } = String.Empty;

        protected async override Task OnInitializedAsync()
        {

            DataFromDifferentPage = NavigationManager?.HistoryEntryState;
            if (DataFromDifferentPage == "Test")
            {
                Console.WriteLine("Testowy test");
            }
        }
    }
}
