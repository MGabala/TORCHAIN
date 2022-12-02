using System.IO;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using TORCHAIN.Repositories;

namespace TORCHAIN.Components.DarknetGallery
{
    public partial class DarknetGalleryView
    {
        [Inject]
        private IForumRepository? _repository { get; set; }
        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        public DarknetGalleryEntity Image { get; set; } = new DarknetGalleryEntity();
        public IEnumerable<DarknetGalleryEntity>? Gallery { get; set; }
        protected bool Fail = true;
        protected bool Success = false;
        protected string Status = string.Empty;

        protected async override Task OnInitializedAsync()
        {
            Gallery = await _repository!.GetAllImages();
        }

        //Upload file
        private IBrowserFile selectedFile = null!;
        private void OnInputFileChange(InputFileChangeEventArgs input)
        {
            selectedFile = input.File;
        }
        private async Task ValidRequest()
        {
            await _repository!.AddImage(selectedFile);
            Gallery = await _repository!.GetAllImages();
        }
        private async Task InvalidRequest()
        {
            Status = "alert-danger";
            Fail = false;
        }
    }
}
