using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;

using TORCHAIN.Repositories;

namespace TORCHAIN.Components
{
    public partial class CategoriesForm
    {
        [Inject]
        private IDbContextFactory<MainDatabase>? _contextFactory { get; set; }
        [Inject]
        private MainDatabase? _context { get; set; }
        [Inject]
        private IForumRepository? _repository { get; set; }
        public CategoryEntity Category { get; set; } = new();
        public IEnumerable<SelectListItem> CategoriesList { get; set; } = null!;
        public IEnumerable<CategoryEntity>? Categories { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //using var factory = _contextFactory?.CreateDbContext();
            //CategoriesList = factory!.Categories.Where(x => x.IsVerified == true).Select(x => new SelectListItem
            //{
            //    Value = x.Category,
            //    Text = x.Category
            //}).ToList();
            Categories = await _repository!.GetAllCategories();
        }
    }
}
