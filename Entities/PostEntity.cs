using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TORCHAIN.Entities
{
    public class PostEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,MinLength(3),MaxLength(50)]
        public string Title { get; set; } = null!;
        [Required, MinLength(3), MaxLength(250)]
        public string Description { get; set; } = null!;
        [Required, MinLength(3), MaxLength(15)]
        public string Author { get; set; } = null!;
        public string Category { get; set; } = null!;
        public DateTime CreationTime { get; set; }
        public bool IsVerified { get; set; }
    }
}
