namespace TORCHAIN.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsVerified { get; set; }
    }
}
