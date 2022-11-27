using System.IO;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TORCHAIN.Repositories;

namespace TORCHAIN.Components.DarknetGallery
{
    public partial class DarknetGalleryView
    {
        [Inject]
        private IForumRepository? _repository { get; set; }
        [Inject]
        private IWebHostEnvironment? _environment { get; set; }
        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        [BindProperty]
        public DarknetGalleryEntity? Media { get; set; }
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
            
            var anonymizedFileName = $"{Guid.NewGuid().ToString()}{selectedFile.Name.Substring(selectedFile.Name.IndexOf('.'))}";
            var path = Path.Combine(_environment!.ContentRootPath, "wwwroot/gallery", anonymizedFileName);
            await using FileStream fs = new(path, FileMode.Create);
            await selectedFile.OpenReadStream().CopyToAsync(fs);
            await _repository!.AddImage(anonymizedFileName, DateTime.Now, false);
            Gallery = await _repository!.GetAllImages();
        }
        private async Task InvalidRequest()
        {
            Status = "alert-danger";
            Fail = false;
        }
    }
}
