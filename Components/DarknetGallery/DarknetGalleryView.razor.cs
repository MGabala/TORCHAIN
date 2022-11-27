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
       

        //Upload file
        private IBrowserFile selectedFile;
        private async void OnInputFileChange(InputFileChangeEventArgs input)
        {
            
            selectedFile = input.File;
            int dotIndex = selectedFile.Name.IndexOf('.');
            var extension = selectedFile.Name.Substring(dotIndex);
            StateHasChanged();
            var path = Path.Combine(_environment!.ContentRootPath, "wwwroot/gallery", $"{Guid.NewGuid().ToString()}{extension}");
            await using FileStream fs = new(path, FileMode.Create);
            await selectedFile.OpenReadStream().CopyToAsync(fs);

        }
        private async Task ValidRequest()
        {

        }
        private async Task InvalidRequest()
        {
            Status = "alert-danger";
            Fail = false;
        }
    }
}
