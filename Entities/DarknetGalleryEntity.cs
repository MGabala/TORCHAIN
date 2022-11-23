using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TORCHAIN.Entities
{
    public class DarknetGalleryEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ImageFileName { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsVerified { get; set; }
    }
}
