namespace LibrarySystem;

public class Book
{
    public int Id { get; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public bool IsAvailable { get; set; } = true;

    public Book(int id, string title, string author, string isbn)
    {
        Id = id;
        Title = title;
        Author = author;
        Isbn = isbn;
    }

    public override string ToString()
    {
        var status = IsAvailable ? "Available" : "Checked Out";
        return $"[{Id}] \"{Title}\" by {Author} (ISBN: {Isbn}) - {status}";
    }
}
