using System.Runtime.CompilerServices;

using Microsoft.AspNetCore.Components;
using TORCHAIN.Repositories;

namespace TORCHAIN.Components
{
    public partial class PostView
    {
        [Inject]
        private IDbContextFactory<MainDatabase>? _contextFactory { get; set; }
        [Inject]
        private MainDatabase? _context { get; set; }
        [Inject]
        private IForumRepository? _repository { get; set; }
        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        public PostEntity Post { get; set; } = new PostEntity();
        public IEnumerable<PostEntity>? Posts { get; set; }

        protected async override Task OnInitializedAsync()
        {
             Posts = await _repository!.GetAllPosts();
        }

    }
}
