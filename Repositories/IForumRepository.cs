using Microsoft.AspNetCore.Components.Forms;

namespace TORCHAIN.Repositories
{
    public interface IForumRepository
    {
        #region Categories
        public Task AddCategory(string category, bool isverified);
        public Task CheckCategory(CategoryEntity category);
        public Task DeleteCategory(int id);
        public Task<IEnumerable<CategoryEntity>> GetAllCategories(bool isVerified);
        #endregion

        #region Posts
        public Task AddPost(string title, string description, string author, string category, bool isverified, DateTime creationtime);
        public Task<IEnumerable<PostEntity>> GetAllPosts(bool isVerified);
        #endregion

        #region Comments
        public Task AddComment(string comment,string author,int postId,bool isVerified,DateTime creationtime);
        public Task<IEnumerable<CommentEntity>> GetAllComments(bool isVerified);
        #endregion
        
        #region HiddenWiki
        public Task<IEnumerable<HiddenWikiEntity>> GetAllWebsites(bool isVerified);
        public Task AddWebsite(string www, string description, bool isVerified, DateTime creationtime);
        #endregion

        #region Gallery
        public Task AddImage(IBrowserFile selectedFile);
        public Task<IEnumerable<DarknetGalleryEntity>> GetAllImages(bool isVerified);
        #endregion
    }
}
