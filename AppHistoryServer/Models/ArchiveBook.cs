namespace AppHistoryServer.Models
{
    public class ArchiveBook
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Title { get; set; } = null!;
        public string FileUrl { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Downloads { get; set; }

        // Relationships
        public ICollection<Question> Questions { get; set; } = null!;
    }
}
