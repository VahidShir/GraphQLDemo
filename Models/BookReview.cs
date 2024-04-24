public class BookReview {
    public int Id { get; set; }
    public int Rating { get; set; }
    public string Text { get; set; }
    public string? User { get; set; }
    public DateTime? ReviewDate { get; set; }
}