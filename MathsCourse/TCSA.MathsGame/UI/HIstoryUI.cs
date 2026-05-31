using Spectre.Console;
using TCSA.MathsGame.Models;
using TCSA.MathsGame.Services;

namespace TCSA.MathsGame.UI;

public class HistoryUI
{
    private readonly GameHistoryService _gameHistoryService;

    public HistoryUI(GameHistoryService gameHistoryService)
    {
        _gameHistoryService = gameHistoryService;
    }

    public void ShowHistory()
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[bold]Game History[/]\n");

        var roundsPlayed = _gameHistoryService.GetGameHistory();

        if (!roundsPlayed.Any())
        {
            AnsiConsole.MarkupLine("[red]No games have been played yet.[/]");
        }
        else
        {
            var tabulatedHistory = DisplayHistoryAsTable(roundsPlayed);
            AnsiConsole.Write(tabulatedHistory);
        }

        AnsiConsole.MarkupLine("[yellow]Press any key to continue:[/]");
        Console.ReadKey();
    }

    private static Table DisplayHistoryAsTable(IReadOnlyList<GameRound> rounds)
    {
        var table = new Table()
            .AddColumn("Game")
            .AddColumn("Date")
            .AddColumn("Time")
            .AddColumn("Operation")
            .AddColumn("Difficulty")
            .AddColumn("Score");

        for (int i = 0; i < rounds.Count; i++)
        {
            var round = rounds[i];

            table.AddRow(
                $"{i + 1}",
                round.PlayedAt.ToString("yyyy-MM-dd"),
                round.PlayedAt.ToString("HH:mm:ss"),
                round.Operation.ToString(),
                round.Difficulty.ToString(),
                $"{round.Score}/{round.MathsQuestions.Count}"
            );
        }

        return table;
    }
}