# 📚 ShelfKeeper — Library Management System

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet&logoColor=white)
![Status](https://img.shields.io/badge/status-active-brightgreen)
![License](https://img.shields.io/badge/license-MIT-blue)

A lightweight console app for running a small library's day-to-day operations — cataloging books, registering members, and tracking who has what checked out.

## ✨ What it does

- 📖 Add, remove, and browse the book catalog
- 🔍 Search books by title, author, or ISBN
- 🧑‍🤝‍🧑 Register library members
- 🔄 Issue and return books, with availability tracked automatically
- 🖥️ Simple menu-driven console interface — no setup beyond the .NET SDK

## 🗂️ Layout

```
LibrarySystem/
└── src/
    ├── LibrarySystem.csproj   # Project file
    ├── Program.cs             # Console menu / entry point
    ├── Library.cs             # Core catalog + issue/return logic
    ├── Book.cs                # Book model
    └── Member.cs               # Member model
```

Kept intentionally flat — everything lives in one `src/` folder rather than being spread across nested layers, since the project is small enough that extra folders would just add noise.

## 🧰 Built with

| Layer     | Choice        |
|-----------|---------------|
| Language  | C# 12         |
| Runtime   | .NET 8        |
| Interface | Console (CLI) |

## ▶️ Running it

**Requirements:** [.NET 8 SDK](https://dotnet.microsoft.com/download)

```bash
git clone https://github.com/<your-username>/shelfkeeper.git
cd shelfkeeper/src
dotnet run
```

The app seeds a couple of sample books and a sample member on startup so you have something to work with right away.

## 🕹️ Usage

On launch you'll see a numbered menu:

```
1. Add Book
2. List Books
3. Search Books
4. Add Member
5. List Members
6. Issue Book
7. Return Book
0. Exit
```

Pick a number and follow the prompts. Book and Member IDs are assigned automatically when you add them — use those IDs when issuing or returning a book.

## 🚧 Possible next steps

- Persist data to a file or database (currently in-memory only, resets on exit)
- Add due dates and overdue tracking
- Swap the console UI for a simple web front end

## 📄 License

Released under the MIT License — free to use for learning or as a starting point for your own project.

## 🙋 Author

Built by [your-username](https://github.com/Srishty889).
