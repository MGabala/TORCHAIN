using System.Runtime.CompilerServices;

using Microsoft.AspNetCore.Components;
using TORCHAIN.Repositories;

namespace TORCHAIN.Components
{
    public partial class PostView
    {
        //[Inject]
        //private IDbContextFactory<MainDatabase>? _contextFactory { get; set; }
        //[Inject]
        //private MainDatabase? _context { get; set; }
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
             Posts = await _repository!.GetAllPosts(isVerified: true);
             Comments = await _repository!.GetAllComments(isVerified: true);
        }

        #region Comments
        protected bool Fail = true;
        protected bool Success = false;
        protected string Status = string.Empty;

        private async Task OnValidComment(int id)
        {
            await Task.Delay(0);

            await _repository!.AddComment(Comment.CommentDescription,Comment.CommentAuthor,id,false,DateTime.Now);
           Comments = await _repository!.GetAllComments(isVerified: true);
            Comment = new();
        }
        private async Task OnInvalidComment()
        {
            await Task.Delay(0);
            Status = "alert-danger";
            Fail = false;
        }

        #endregion

        #region SearchBox
        public string SearchTerm { get; set; } = string.Empty;

        public List<PostEntity> FilteredPosts = new List<PostEntity>();
        public async Task FilterPosts()
        {
            await Task.Delay(0);

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                FilteredPosts = Posts
                .Where(x => x.Title.ToLower().Contains(SearchTerm.ToLower())).ToList();
            }
            else
            {
                FilteredPosts = new();
            }
        }
        #endregion
    }
}
