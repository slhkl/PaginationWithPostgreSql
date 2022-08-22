namespace Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Writer { get; set; }
        public DateTime AddedTime { get; set; } = DateTime.UtcNow;
    }
}
