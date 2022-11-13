using Microsoft.AspNetCore.Mvc.Rendering;

namespace TORCHAIN.Repositories
{
    public class ForumRepository : IForumRepository
    {
        private readonly IDbContextFactory<MainDatabase> _contextFactory;
        private readonly MainDatabase _context;
        public ForumRepository(IDbContextFactory<MainDatabase> contextFactory, MainDatabase context)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region Categories
        public async Task AddCategory(string category, bool isverified)
        {
            using var factory = _contextFactory.CreateDbContext();
            await factory.Categories.AddAsync(new CategoryEntity
            {
                Category = category,
                IsVerified = isverified
            });
            await factory.SaveChangesAsync();
        }

        public async Task CheckCategory(CategoryEntity category)
        {
            using var factory = _contextFactory.CreateDbContext();
            var categoryForApprove = await factory.Categories.SingleOrDefaultAsync(x=>x.Id == category.Id);
            categoryForApprove!.IsVerified = true;
            await factory.SaveChangesAsync();

        }
#pragma warning disable CS8634 
        public async Task DeleteCategory(int id)
        {
            using var factory = _contextFactory.CreateDbContext();
            var category = await factory.Categories.FirstOrDefaultAsync(x=>x.Id == id);
            factory!.Remove(category);
            await factory.SaveChangesAsync();
        }
#pragma warning restore CS8634

        public async Task<IEnumerable<CategoryEntity>> GetAllCategories()
        {
           return await _context.Categories.OrderBy(x=>x.Id).ToListAsync();
        }

        #endregion
    }
}
