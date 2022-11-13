namespace TORCHAIN.Repositories
{
    public class ForumRepository : IForumRepository
    {
        private IDbContextFactory<MainDatabase> _context;
        public ForumRepository(IDbContextFactory<MainDatabase> context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region Categories
        public async Task AddCategory(string category, bool isverified)
        {
            using var factory = _context.CreateDbContext();
            await factory.Categories.AddAsync(new CategoryEntity
            {
                Category = category,
                IsVerified = isverified
            });
            await factory.SaveChangesAsync();
        }

        public async Task CheckCategory(CategoryEntity category)
        {
            using var factory = _context.CreateDbContext();
            var categoryForApprove = await factory.Categories.SingleOrDefaultAsync(x=>x.Id == category.Id);
            categoryForApprove!.IsVerified = true;
            await factory.SaveChangesAsync();

        }

        public async Task DeleteCategory(int id)
        {
            using var factory = _context.CreateDbContext();
            var category = await factory.Categories.FirstOrDefaultAsync(x=>x.Id == id);
            factory.RemoveAsync(category);
            await factory.SaveChangesAsync();
        }
        #endregion
    }
}
