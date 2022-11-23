using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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
        public DarknetGalleryEntity DarknetGallery { get; set; } = new DarknetGalleryEntity();
        public IEnumerable<DarknetGalleryEntity>? Gallery { get; set; }
        protected bool Fail = true;
        protected bool Success = false;
        protected string Status = string.Empty;

        //Upload file
        private IBrowserFile selectedFile;
        private void OnInputFileChange(InputFileChangeEventArgs input)
        {
            selectedFile = input.File;
            StateHasChanged();

            ////handle image upload
            //string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
            //var path = $"\\wwwroot\\gallery";
            //var fileStream = System.IO.File.Create(path);
            //fileStream.Write(employee.ImageContent, 0, employee.ImageContent.Length);
            //fileStream.Close();

        }
    }
}
