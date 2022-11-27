namespace TORCHAIN.Repositories
{
    public interface IForumRepository
    {
        #region Categories
        public Task AddCategory(string category, bool isverified);
        public Task CheckCategory(CategoryEntity category);
        public Task DeleteCategory(int id);
        public Task<IEnumerable<CategoryEntity>> GetAllCategories();
        #endregion

        #region Posts
        public Task AddPost(string title, string description, string author, string category, bool isverified, DateTime creationtime);
        public Task<IEnumerable<PostEntity>> GetAllPosts();
        #endregion

        #region Comments
        public Task AddComment(string comment,string author,int postId,bool isVerified,DateTime creationtime);
        public Task<IEnumerable<CommentEntity>> GetAllComments();
        #endregion
        #region HiddenWiki
        public Task<IEnumerable<HiddenWikiEntity>> GetAllWebsites();
        public Task AddWebsite(string www, string description, bool isVerified, DateTime creationtime);
        #endregion

        #region Gallery
        public Task AddImage(string name, DateTime creationTime, bool isVerified);
        public Task<IEnumerable<DarknetGalleryEntity>> GetAllImages();
        #endregion
    }
}
