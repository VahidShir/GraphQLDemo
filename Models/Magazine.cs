public class Magazine : IReadingMaterials, IThings
{
    public int Id { get; set; }
    public string Name { get; set; }
    public BookGenre? Genre { get; set; }
    public int IssueNo { get; set; }
}