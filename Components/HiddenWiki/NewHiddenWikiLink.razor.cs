using Microsoft.AspNetCore.Components;
using TORCHAIN.Repositories;

namespace TORCHAIN.Components.HiddenWiki
{
    public partial class NewHiddenWikiLink
    {
        [Inject]
        private IForumRepository? _repository { get; set; }
        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        public HiddenWikiEntity Website { get; set; } = new HiddenWikiEntity();
        public IEnumerable<HiddenWikiEntity>? Websites { get; set; }
    }
}
