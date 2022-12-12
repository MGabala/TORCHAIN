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
        public PostEntity Post { get; set; } = new PostEntity();
        public CommentEntity Comment { get; set; } = new CommentEntity();
        public CategoryEntity Category { get; set; } = new CategoryEntity();
        public DarknetGalleryEntity GalleryItem { get; set; } = new DarknetGalleryEntity();
        protected async override Task OnInitializedAsync()
        {
            Posts = await _repository!.GetAllPosts();
            Comments = await _repository!.GetAllComments();
            Categories = await _repository!.GetAllCategories(isVerified: false);
            Gallery = await _repository!.GetAllImages(isVerified: false);
        }
        private async Task AcceptPost(int id)
        {
          
        }
        private async Task DenyPost(int id)
        {

        }
        private async Task AcceptComment(int id)
        {
            
        }
        private async Task DenyComment(int id)
        {

        }
        private async Task AcceptCategory(int id)
        {

        }
        private async Task DenyCategory(int id)
        {
            
        }
        private async Task AcceptGalleryItem(int id)
        {

        }
        private async Task DenyGalleryItem(int id)
        {

        }
    }
}
