using System.Runtime.CompilerServices;

using Microsoft.AspNetCore.Components;
using TORCHAIN.Repositories;

namespace TORCHAIN.Pages
{
    public partial class Admin
    {
        [Inject]
        private IForumRepository? _repository { get; set; }
        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        public IEnumerable<PostEntity>? Posts { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Posts = await _repository!.GetAllPosts();
        }
    }
}
