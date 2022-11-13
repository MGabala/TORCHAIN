namespace TORCHAIN.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Category { get; set; } = null!;
        public DateTime CreationTime { get; set; }
        public bool IsVerified { get; set; }
    }
}
