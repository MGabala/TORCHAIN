using System;

using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace TORCHAIN.Repositories
{
    public class ForumRepository : IForumRepository
    {
        private readonly IDbContextFactory<MainDatabase> _contextFactory;
        private readonly MainDatabase _context;
        private IWebHostEnvironment? _environment { get; set; }
        public ForumRepository(IDbContextFactory<MainDatabase> contextFactory, MainDatabase context, IWebHostEnvironment environment)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
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

        public async Task<IEnumerable<CategoryEntity>> GetAllCategories(bool isVerified)
        {
           return await _context.Categories.OrderBy(x=>x.Id).Where(x=>x.IsVerified == isVerified).ToListAsync();
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

        public async Task<IEnumerable<PostEntity>> GetAllPosts(bool isVerified)
        {
            return await _context.Posts.OrderByDescending(x => x.Id).Where(x => x.IsVerified == isVerified).ToListAsync();
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
        public async Task<IEnumerable<CommentEntity>> GetAllComments(bool isVerified)
        {
            return await _context.Comments.OrderByDescending(x=>x.Id).Where(x => x.IsVerified == isVerified).ToListAsync();
        }
        #endregion

        #region HiddenWiki
        public async Task<IEnumerable<HiddenWikiEntity>> GetAllWebsites(bool isVerified)
        {
            using var factory = _contextFactory.CreateDbContext();
            return await factory.Websites.OrderBy(x => x.Id).Where(x => x.IsVerified == isVerified).ToListAsync();
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

        #region Gallery
        public async Task AddImage(IBrowserFile selectedFile)
        {
            long maxallowedsize = 1024*3000;
            var anonymizedFileName = $"{Guid.NewGuid().ToString()}{selectedFile.Name.Substring(selectedFile.Name.IndexOf('.'))}";
            var path = Path.Combine(_environment!.ContentRootPath, "wwwroot/gallery", anonymizedFileName);
            await using FileStream fs = new(path, FileMode.Create);
            await selectedFile.OpenReadStream(maxallowedsize).CopyToAsync(fs);
            using var factory = _contextFactory.CreateDbContext();
            await factory.DarknetGallery.AddAsync(new DarknetGalleryEntity
            {
                ImageFileName = anonymizedFileName,
                CreationTime = DateTime.Now,
                IsVerified = false
            });
            await factory.SaveChangesAsync();
        }

        public async Task<IEnumerable<DarknetGalleryEntity>> GetAllImages(bool isVerified)
        {
            using var factory = _contextFactory.CreateDbContext();
            return await factory.DarknetGallery.OrderBy(x=>x.Id).Where(x=>x.IsVerified == isVerified).ToListAsync();
        }
        #endregion

        #region Admin
        public async Task Accept(int id,Type type)
        {
            
            if (type == typeof(PostEntity))
            {
                using var factory = _contextFactory.CreateDbContext();
                var post = await factory.Posts.SingleOrDefaultAsync( x => x.Id == id);
                post!.IsVerified = true;
                await factory.SaveChangesAsync();

            }
            if (type == typeof(CommentEntity))
            {
                using var factory = _contextFactory.CreateDbContext();
                var post = await factory.Comments.SingleOrDefaultAsync(x => x.Id == id);
                post!.IsVerified = true;
                await factory.SaveChangesAsync();

            }
            if (type == typeof(CategoryEntity))
            {
                using var factory = _contextFactory.CreateDbContext();
                var post = await factory.Categories.SingleOrDefaultAsync(x => x.Id == id);
                post!.IsVerified = true;
                await factory.SaveChangesAsync();

            }
            if (type == typeof(DarknetGalleryEntity))
            {
                using var factory = _contextFactory.CreateDbContext();
                var post = await factory.DarknetGallery.SingleOrDefaultAsync(x => x.Id == id);
                post!.IsVerified = true;
                await factory.SaveChangesAsync();

            }
        }

        public async Task Deny(int id,Type type)
        {
#pragma warning disable CS8634
            if (type == typeof(PostEntity))
            {
                using var factory = _contextFactory.CreateDbContext();
                var post = await factory.Posts.FirstOrDefaultAsync(x => x.Id == id);
                factory!.Remove(post);
                await factory.SaveChangesAsync();
            }
            if (type == typeof(CommentEntity))
            {
                using var factory = _contextFactory.CreateDbContext();
                var comment = await factory.Comments.FirstOrDefaultAsync(x => x.Id == id);
                factory!.Remove(comment);
                await factory.SaveChangesAsync();
            }
            if (type == typeof(CategoryEntity))
            {
                using var factory = _contextFactory.CreateDbContext();
                var category = await factory.Categories.FirstOrDefaultAsync(x => x.Id == id);
                factory!.Remove(category);
                await factory.SaveChangesAsync();
            }
            if (type == typeof(DarknetGalleryEntity))
            {
                using var factory = _contextFactory.CreateDbContext();
                var galleryItem = await factory.DarknetGallery.FirstOrDefaultAsync(x => x.Id == id);
                factory!.Remove(galleryItem);
                await factory.SaveChangesAsync();
            }
#pragma warning restore CS8634
        }
        #endregion
    }
}
