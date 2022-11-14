using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TORCHAIN.Entities
{
    public class CategoryEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,MinLength(3)]
        public string? Category { get; set; }
        public bool IsVerified { get; set; } 
    }
}
