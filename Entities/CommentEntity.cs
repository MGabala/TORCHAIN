using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TORCHAIN.Entities
{
    public class CommentEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CommentDescription { get; set; } = string.Empty;
        public string CommentAuthor { get; set; } = string.Empty;
        public int PostId { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
