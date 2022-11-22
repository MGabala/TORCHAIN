using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TORCHAIN.Entities
{
    public class HiddenWikiEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string WWW { get; set; } = null!;
        public bool IsVerified { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreationTime { get; set; }
    }
}
