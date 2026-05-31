using Spectre.Console;
using TCSA.MathsGame.Enums;

namespace TCSA.MathsGame.UI;

public class MenuUI
{
    private readonly GameUI _gameUI;
    private readonly HistoryUI _historyUI;

    public MenuUI(GameUI gameUI, HistoryUI historyUI)
    {
        _gameUI = gameUI;
        _historyUI = historyUI;
    }

    public void Run()
    {
        var running = true;

        while (running)
        {
            AnsiConsole.Clear();

            var action = AnsiConsole.Prompt(
                new SelectionPrompt<TopMenu>()
                .Title("What would you like to do?")
                .AddChoices(Enum.GetValues<TopMenu>())
            );

            switch (action)
            {
                case TopMenu.PlayGame:
                    _gameUI.Run();
                    break;
                case TopMenu.ShowHistory:
                    AnsiConsole.MarkupLine("[red]CALLED SHOW HISTORY[/]");
                    _historyUI.ShowHistory();
                    break;
                case TopMenu.Quit:
                    running = false;
                    break;
            }
        }

        AnsiConsole.MarkupLine("Bye, thanks for playing.");
    }
}