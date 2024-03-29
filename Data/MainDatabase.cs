﻿
using TORCHAIN.Pages;

namespace TORCHAIN.Data
{
    public class MainDatabase : DbContext
    {
        public MainDatabase(DbContextOptions<MainDatabase> options) : base(options)
        {

        }
        public DbSet<PostEntity> Posts => Set<PostEntity>();
        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<CommentEntity> Comments => Set<CommentEntity>();
        public DbSet<HiddenWikiEntity> Websites => Set<HiddenWikiEntity>();
        public DbSet<DarknetGalleryEntity> DarknetGallery => Set<DarknetGalleryEntity>();
    }
}
