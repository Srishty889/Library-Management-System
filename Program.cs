namespace LibrarySystem;

public static class Program
{
    private static readonly Library Library = new();

    public static void Main()
    {
        SeedSampleData();

        var running = true;
        while (running)
        {
            PrintMenu();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddBook(); break;
                case "2": ListBooks(); break;
                case "3": SearchBooks(); break;
                case "4": AddMember(); break;
                case "5": ListMembers(); break;
                case "6": IssueBook(); break;
                case "7": ReturnBook(); break;
                case "0": running = false; break;
                default: Console.WriteLine("Invalid option, try again.\n"); break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    private static void PrintMenu()
    {
        Console.WriteLine("===== Library Management System =====");
        Console.WriteLine("1. Add Book");
        Console.WriteLine("2. List Books");
        Console.WriteLine("3. Search Books");
        Console.WriteLine("4. Add Member");
        Console.WriteLine("5. List Members");
        Console.WriteLine("6. Issue Book");
        Console.WriteLine("7. Return Book");
        Console.WriteLine("0. Exit");
        Console.Write("Choose an option: ");
    }

    private static void AddBook()
    {
        Console.Write("Title: ");
        var title = Console.ReadLine() ?? "";
        Console.Write("Author: ");
        var author = Console.ReadLine() ?? "";
        Console.Write("ISBN: ");
        var isbn = Console.ReadLine() ?? "";

        var book = Library.AddBook(title, author, isbn);
        Console.WriteLine($"Added: {book}\n");
    }

    private static void ListBooks()
    {
        Console.WriteLine("--- Book Catalog ---");
        foreach (var book in Library.GetAllBooks())
            Console.WriteLine(book);
        Console.WriteLine();
    }

    private static void SearchBooks()
    {
        Console.Write("Search keyword (title/author/ISBN): ");
        var keyword = Console.ReadLine() ?? "";
        var results = Library.SearchBooks(keyword).ToList();

        Console.WriteLine(results.Count == 0 ? "No matches found.\n" : "--- Results ---");
        foreach (var book in results)
            Console.WriteLine(book);
        Console.WriteLine();
    }

    private static void AddMember()
    {
        Console.Write("Name: ");
        var name = Console.ReadLine() ?? "";
        Console.Write("Email: ");
        var email = Console.ReadLine() ?? "";

        var member = Library.AddMember(name, email);
        Console.WriteLine($"Added: {member}\n");
    }

    private static void ListMembers()
    {
        Console.WriteLine("--- Members ---");
        foreach (var member in Library.GetAllMembers())
            Console.WriteLine(member);
        Console.WriteLine();
    }

    private static void IssueBook()
    {
        var bookId = ReadInt("Book ID: ");
        var memberId = ReadInt("Member ID: ");
        Console.WriteLine(Library.IssueBook(bookId, memberId) + "\n");
    }

    private static void ReturnBook()
    {
        var bookId = ReadInt("Book ID: ");
        var memberId = ReadInt("Member ID: ");
        Console.WriteLine(Library.ReturnBook(bookId, memberId) + "\n");
    }

    private static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        return int.TryParse(Console.ReadLine(), out var value) ? value : -1;
    }

    private static void SeedSampleData()
    {
        Library.AddBook("Clean Code", "Robert C. Martin", "9780132350884");
        Library.AddBook("The Pragmatic Programmer", "Andrew Hunt", "9780201616224");
        Library.AddMember("Aarav Sharma", "aarav.sharma@example.com");
    }
}
