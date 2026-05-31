using System.ComponentModel;
using Spectre.Console;
using TCSA.MathsGame.Enums;
using TCSA.MathsGame.Models;
using TCSA.MathsGame.Services;

namespace TCSA.MathsGame.UI;

public class GameUI
{
    private readonly MathsQuestionGenerator _mathsQuestionGenerator;
    private readonly GameHistoryService _gameHistroyService;

    public GameUI(MathsQuestionGenerator mathsQuestionGenerator, GameHistoryService gameHistoryService)
    {
        _mathsQuestionGenerator = mathsQuestionGenerator;
        _gameHistroyService = gameHistoryService;
    }

    public void Run()
    {
        // get operation
        var mathsOperation = OperationMenu();
        // get difficulty
        var difficultyLevel = DifficultyMenu();
        // generate questions
        var questions = _mathsQuestionGenerator.GenerateMathsQuestions(mathsOperation, difficultyLevel);
        // create game round
        var round = new GameRound
        {
            Operation = mathsOperation,
            Difficulty = difficultyLevel,
            MathsQuestions = questions

        };
        // ask qeustions and get response

        for (int i = 0; i < questions.Count; i++)
        {
            AskQuestion(i + 1, questions[i]);
        }
        // save round

        _gameHistroyService.Save(round);
        var endOfRoundPrompt = $"End of the game. You scored [yellow]{round.Score}[/] out of [blue]{round.MathsQuestions.Count}[/]";
        AnsiConsole.MarkupLine(endOfRoundPrompt);
        AnsiConsole.MarkupLine("[yellow]Press any key to continue.[/]");
        Console.ReadKey();
    }

    private Operation OperationMenu()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<Operation>()
            .Title("Select an [green]operation[/]:")
            .AddChoices(Enum.GetValues<Operation>())
        );
    }

    private Difficulty DifficultyMenu()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<Difficulty>()
            .Title("Select a [green]difficulty[/]:")
            .AddChoices(Enum.GetValues<Difficulty>())
        );
    }

    private void AskQuestion(int questionNumber, MathsQuestion question)
    {

        var questionPrompt = $"{questionNumber}) [blue]{question.ToString()}[/]";

        var answer = AnsiConsole.Prompt(
                new TextPrompt<int>(questionPrompt)
                    .ValidationErrorMessage("[red]Please enter a valid whole number[/].`")
        );

        question.UserAnswer = answer;

        if (question.IsCorrect)
        {
            AnsiConsole.MarkupLine("[green]CORRECT[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]WRONG[/]");
        }
    }
}