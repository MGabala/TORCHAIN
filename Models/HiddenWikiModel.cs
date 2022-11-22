namespace TORCHAIN.Models
{
    public class HiddenWikiModel
    {
        public int Id { get; set; }
        public string WWW { get; set; } = null!;
        public bool IsVerified { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreationTime { get; set; }
    }
}
