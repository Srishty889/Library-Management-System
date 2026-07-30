namespace LibrarySystem;

public class Library
{
    private readonly List<Book> _books = new();
    private readonly List<Member> _members = new();
    private int _nextBookId = 1;
    private int _nextMemberId = 1;

    // ---------- Books ----------

    public Book AddBook(string title, string author, string isbn)
    {
        var book = new Book(_nextBookId++, title, author, isbn);
        _books.Add(book);
        return book;
    }

    public bool RemoveBook(int bookId)
    {
        var book = _books.FirstOrDefault(b => b.Id == bookId);
        if (book is null) return false;
        return _books.Remove(book);
    }

    public IReadOnlyList<Book> GetAllBooks() => _books.AsReadOnly();

    public IEnumerable<Book> SearchBooks(string keyword)
    {
        keyword = keyword.Trim().ToLowerInvariant();
        return _books.Where(b =>
            b.Title.ToLowerInvariant().Contains(keyword) ||
            b.Author.ToLowerInvariant().Contains(keyword) ||
            b.Isbn.ToLowerInvariant().Contains(keyword));
    }

    // ---------- Members ----------

    public Member AddMember(string name, string email)
    {
        var member = new Member(_nextMemberId++, name, email);
        _members.Add(member);
        return member;
    }

    public IReadOnlyList<Member> GetAllMembers() => _members.AsReadOnly();

    // ---------- Issue / Return ----------

    public string IssueBook(int bookId, int memberId)
    {
        var book = _books.FirstOrDefault(b => b.Id == bookId);
        var member = _members.FirstOrDefault(m => m.Id == memberId);

        if (book is null) return "Book not found.";
        if (member is null) return "Member not found.";
        if (!book.IsAvailable) return $"\"{book.Title}\" is already checked out.";

        book.IsAvailable = false;
        member.BorrowedBookIds.Add(book.Id);
        return $"\"{book.Title}\" issued to {member.Name}.";
    }

    public string ReturnBook(int bookId, int memberId)
    {
        var book = _books.FirstOrDefault(b => b.Id == bookId);
        var member = _members.FirstOrDefault(m => m.Id == memberId);

        if (book is null) return "Book not found.";
        if (member is null) return "Member not found.";
        if (!member.BorrowedBookIds.Contains(bookId)) return $"{member.Name} has not borrowed this book.";

        book.IsAvailable = true;
        member.BorrowedBookIds.Remove(bookId);
        return $"\"{book.Title}\" returned by {member.Name}.";
    }
}
