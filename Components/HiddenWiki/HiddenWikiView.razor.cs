using Microsoft.AspNetCore.Components;
using TORCHAIN.Repositories;

namespace TORCHAIN.Components.HiddenWiki
{
    public partial class HiddenWikiView
    {
        [Inject]
        private IForumRepository? _repository { get; set; }
        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        public HiddenWikiEntity Website { get; set; } = new HiddenWikiEntity();
        public IEnumerable<HiddenWikiEntity>? Websites { get; set; }
        protected bool Fail = true;
        protected bool Success = false;
        protected string Status = string.Empty;
        protected async override Task OnInitializedAsync()
        {
            Websites = await _repository!.GetAllWebsites(isVerified: true);
        }
        private async Task ValidRequest()
        {
            try
            {
                await _repository!.AddWebsite(Website.WWW, Website.Description, false, DateTime.Now);
                Status = "alert-success";
                Success = true;
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        private async Task InvalidRequest()
        {
            Status = "alert-danger";
            Fail = false;
        }

    }
}
