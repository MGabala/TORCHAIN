using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;

using TORCHAIN.Models;
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
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public CategoryEntity Category { get; set; } = new CategoryEntity();
        public CategoryEntity NewCategory { get; set; } = new CategoryEntity();
        public IEnumerable<SelectListItem> CategoriesList { get; set; } = null!;
        public IEnumerable<CategoryEntity>? Categories { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Categories = await _repository!.GetAllCategories();
        }
        #region AddNewCategory
        protected bool Fail = true;
        protected bool Success = false;
        protected string Status = string.Empty;

        private async Task AddCategory()
        {
            await _repository!.AddCategory(category: NewCategory.Category!,isverified: false);
            Status = "alert-success";
            Success = true;
            Categories = await _repository!.GetAllCategories();
            
        }
        private async Task Invalid()
        {
            Status = "alert-danger";
            Fail = false;
        }

        #endregion
    }
}
