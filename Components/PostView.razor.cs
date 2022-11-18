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
        public CommentEntity Comment { get; set; } = new CommentEntity();
        public IEnumerable<PostEntity>? Posts { get; set; }
        public IEnumerable<CommentEntity>? Comments { get; set; }

        protected async override Task OnInitializedAsync()
        {
             Posts = await _repository!.GetAllPosts();
             Comments = await _repository!.GetAllComments();
        }
        #region Comments
        protected bool Fail = true;
        protected bool Success = false;
        protected string Status = string.Empty;

        private async Task OnValidComment()
        {
           await _repository!.AddComment(Comment.CommentDescription,Comment.CommentAuthor,1,false,DateTime.Now);
           Comments = await _repository!.GetAllComments();
        }
        private async Task OnInvalidComment()
        {
            Status = "alert-danger";
            Fail = false;
        }

        #endregion
    }
}
