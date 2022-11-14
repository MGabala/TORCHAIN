using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using TORCHAIN.Repositories;

namespace TORCHAIN.Components
{
    public partial class PostForm
    {
        [Inject]
        private IDbContextFactory<MainDatabase>? _contextFactory { get; set; }
        [Inject]
        private MainDatabase? _context { get; set; }
        [Inject]
        private IForumRepository? _repository { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public PostEntity Post { get; set; } = new PostEntity();
        public IEnumerable<PostEntity>? Posts { get; set; }
        public IEnumerable<CategoryEntity>? Categories { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Categories = await _repository!.GetAllCategories();
        }

        #region AddNewPost
        protected bool Fail = true;
        protected bool Success = false;
        protected string Status = string.Empty;

        private async Task AddPost()
        {

        }
        private async Task Invalid()
        {

        }

        #endregion
    }
}
