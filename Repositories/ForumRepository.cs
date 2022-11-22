﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

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

        #region Posts
        public async Task AddPost(string title, string description, string author, string category, bool isverified, DateTime creationtime)
        {
            await _context.Posts.AddAsync(new PostEntity
            {
                Title = title,
                Description = description,
                Author = author,
                Category = category,
                IsVerified = isverified,
                CreationTime = creationtime
            });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostEntity>> GetAllPosts()
        {
            return await _context.Posts.OrderByDescending(x => x.Id).ToListAsync();
        }

        #endregion

        #region Comments
        public async Task AddComment(string comment, string author, int postId, bool isVerified, DateTime creationtime)
        {
            await _context.Comments.AddAsync(new CommentEntity
            {
                CommentDescription = comment,
                CommentAuthor = author,
                PostId = postId,
                IsVerified = isVerified,
                CreationTime = creationtime
            });
           await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<CommentEntity>> GetAllComments()
        {
            return await _context.Comments.OrderByDescending(x=>x.Id).ToListAsync();
        }
        #endregion

        #region HiddenWiki
        public async Task<IEnumerable<HiddenWikiEntity>> GetAllWebsites()
        {
            using var factory = _contextFactory.CreateDbContext();
            return await factory.Websites.OrderBy(x => x.Id).ToListAsync();
        }
        public async Task AddWebsite(string www, string description, bool isVerified, DateTime creationtime)
        {
            using var factory = _contextFactory.CreateDbContext();
            await factory.Websites.AddAsync(new HiddenWikiEntity
            {
                WWW = www,
                Description = description,
                IsVerified = isVerified,
                CreationTime = creationtime
            });
            await factory.SaveChangesAsync();
        }
        #endregion
    }
}
