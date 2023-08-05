namespace AppHistoryServer.Models
{
    public class ArchiveCourse
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string FileUrl { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Downloads { get; set; }
    }
}
