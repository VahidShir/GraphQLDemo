using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

public class Query
{
    // public List<Book> Books => ReadData<Book>();
    public List<Magazine> Magazines => ReadData<Magazine>();
    public List<IThings> Things => ReadThings();

    private List<IThings> ReadThings()
    {
        var things = ReadData<Book>().Cast<IThings>().ToList();
        things.AddRange(ReadData<Magazine>().Cast<IThings>());
        return things;
    }

    private List<Magazine> ReadMagazines()
    {
        string fileName = "Database/magazines.json";
        string jsonString = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<List<Magazine>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;
    }

    public List<Book> Books(string name = "")
    {
        string fileName = "Database/books.json";
        string jsonString = File.ReadAllText(fileName);
        var allBooks = JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;
        return allBooks.Where(b => b.Name.ToLower().Contains(name.ToLower())).ToList();
    }

    private List<T> ReadData<T>()
    {
        string fileName = $"Database/{typeof(T).Name}s.json";
        string jsonString = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<List<T>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;
    }
}