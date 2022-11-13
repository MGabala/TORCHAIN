using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;

using TORCHAIN.Repositories;

namespace TORCHAIN.Components
{
    public partial class CategoriesForm
    {

        [Inject]
        private IDbContextFactory<MainDatabase> _contextFactory { get; set; }

        public IEnumerable<SelectListItem> CategoriesList { get; set; } = null!;
        protected async override Task OnInitializedAsync()
        {
            using var factory = _contextFactory.CreateDbContext();
           CategoriesList = factory.Categories.Where(x => x.IsVerified == true).Select(x => new SelectListItem
           {
               Value = x.Category,
               Text = x.Category
           }).ToList();
        }
    }
}
