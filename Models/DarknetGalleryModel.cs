using System.ComponentModel.DataAnnotations.Schema;

namespace TORCHAIN.Models
{
    public partial class DarknetGalleryModel
    {
        public int Id { get; set; }
        public string ImageFileName { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsVerified { get; set; }
    }
}
