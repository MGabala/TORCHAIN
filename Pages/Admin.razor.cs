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
        public IEnumerable<CommentEntity>? Comments { get; set; }
        public IEnumerable<CategoryEntity>? Categories { get; set; }
        public IEnumerable<DarknetGalleryEntity>? Gallery { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Posts = await _repository!.GetAllPosts();
            Comments = await _repository!.GetAllComments();
            Categories = await _repository!.GetAllCategories(isVerified: false);
            Gallery = await _repository!.GetAllImages(isVerified: false);
        }
    }
}
