namespace TORCHAIN.Repositories
{
    public class ForumRepository : IForumRepository
    {
        #region Categories
        public Task AddCategory(string category, bool isverified)
        {
            throw new NotImplementedException();
        }

        public Task CheckCategory(CategoryEntity category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
