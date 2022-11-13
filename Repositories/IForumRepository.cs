namespace TORCHAIN.Repositories
{
    public interface IForumRepository
    {
        public Task AddCategory(string category, bool isverified);
        public Task CheckCategory(CategoryEntity category);
        public Task DeleteCategory(int id);
    }
}
