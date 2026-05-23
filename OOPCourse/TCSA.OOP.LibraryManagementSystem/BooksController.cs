using Spectre.Console;


namespace TSCA.OOP.LibraryManagementSystem;

internal class BooksController
{
    internal void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of Books: [/]");

        foreach (var book in MockDatabase.Books)
        {
            AnsiConsole.MarkupLine($"- [cyan]{book.Name}[/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue: ");
        Console.ReadKey();
    }

    internal void AddBook()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
        var pages = AnsiConsole.Ask<int>("Enter the [green]number[/] of pages:");
        if (MockDatabase.Books.Exists(b => b.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            AnsiConsole.MarkupLine("[red]This book already exists.[/]");
        }
        else
        {
            Book newBook = new Book(title, pages);
            MockDatabase.Books.Add(newBook);
            AnsiConsole.MarkupLine("[green]Book has been added.[/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue: ");
        Console.ReadKey();
    }

    internal void DeleteBook()
    {
        if (MockDatabase.Books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books available to delete![/]");
            Console.ReadKey();
            return;
        }

        var bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Book>()
                .Title("Select a [red]book[/] to delete:")
                .UseConverter(b => $"{b.Name}")
                .AddChoices(MockDatabase.Books)
        );

        if (MockDatabase.Books.Remove(bookToDelete))
        {
            AnsiConsole.MarkupLine("[red]Book has been deleted.[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Book not found.[/]");

        }

        AnsiConsole.MarkupLine("Press any key to continue.");
        Console.ReadKey();
    }
}