using Spectre.Console;
using static TSCA.OOP.LibraryManagementSystem.Enums;

namespace TSCA.OOP.LibraryManagementSystem;

internal class UserInterface
{
    private BooksController booksController = new();

    internal void MainMenu()
    {
        while (true)
        {
            Console.Clear();

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOption>()
                    .Title("What do you want to do next?")
                    .AddChoices(Enum.GetValues<MenuOption>())
                );

            switch (choice)
            {
                case MenuOption.ViewBook:
                    booksController.ViewBooks();
                    break;
                case MenuOption.AddBook:
                    booksController.AddBook();
                    break;
                case MenuOption.DeleteBook:
                    booksController.DeleteBook();
                    break;
            }
        }




    }
}