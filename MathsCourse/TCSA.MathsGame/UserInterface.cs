using Spectre.Console;
using static TCSA.MathsGame.Enums;

namespace TCSA.MathsGame;

internal class UserInterface
{
    internal void MainMenu()
    {
        while (true)
        {
            Console.Clear();

            var actionChoice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuTopLevel>()
                .Title("What would you like to do?")
                .AddChoices(Enum.GetValues<MenuTopLevel>())
            );

            switch (actionChoice)
            {
                case MenuTopLevel.PlayGame:
                    SubMenuOperations();
                    Console.ReadKey();
                    break;
                case MenuTopLevel.ScoreHistory:
                    Console.WriteLine("Here is your history");
                    Console.ReadKey();
                    break;
                case MenuTopLevel.Quit:
                    Console.WriteLine("Quitting");
                    System.Environment.Exit(0);
                    break;
            }
        }
    }

    private void SubMenuOperations()
    {
        var operationChoice = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOperation>()
            .Title("What maths operation would you like to do>")
            .AddChoices(Enum.GetValues<MenuOperation>())
        );

        switch (operationChoice)
        {
            case MenuOperation.Add:
                Console.WriteLine("Adding");
                Console.ReadKey();
                break;
            case MenuOperation.Subtract:
                Console.WriteLine("Substracting");
                Console.ReadKey();
                break;
            case MenuOperation.Multiply:
                Console.WriteLine("Multiplying");
                Console.ReadKey();
                break;
            case MenuOperation.Divide:
                Console.WriteLine("Dividing");
                Console.ReadKey();
                break;
            case MenuOperation.Random:
                Console.WriteLine("Random");
                Console.ReadKey();
                break;
        }
    }
}