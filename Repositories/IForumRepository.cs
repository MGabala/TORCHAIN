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
    }
}
