namespace LibrarySystem;

public class Member
{
    public int Id { get; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<int> BorrowedBookIds { get; } = new();

    public Member(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public override string ToString()
    {
        return $"[{Id}] {Name} ({Email}) - Books borrowed: {BorrowedBookIds.Count}";
    }
}
