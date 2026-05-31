using TCSA.MathsGame.Config;
using TCSA.MathsGame.Enums;
using TCSA.MathsGame.Models;


namespace TCSA.MathsGame.Services;

public sealed class MathsQuestionGenerator
{
    private readonly Random rng = new();
    private readonly GameSettings _settings;

    public MathsQuestionGenerator(GameSettings settings)
    {
        _settings = settings;
    }

    public List<MathsQuestion> GenerateMathsQuestions(Operation operation, Difficulty difficulty)
    {
        List<MathsQuestion> questions = new();

        for (int i = 0; i < _settings.RoundsPerGame; i++)
        {
            questions.Add(GenerateOneMathsQuestion(operation, difficulty));
        }

        return questions;
    }

    private MathsQuestion GenerateOneMathsQuestion(Operation operation, Difficulty difficulty)
    {
        var range = _settings.Difficulties[difficulty];

        return operation switch

        {
            Operation.Addition => GenerateAdditionQuestion(range.MinimumNumber, range.MaximumNumber),
            Operation.Subtraction => GenerateSubtractionQuestion(range.MinimumNumber, range.MaximumNumber),
            Operation.Multiplication => GenerateMultiplicationQuestion(range.MinimumNumber, range.MaximumNumber),
            Operation.Division => GenerateDivisionQuestion(range.MinimumNumber, range.MaximumNumber),
            Operation.Mixed => GenerateMixedMathsQuestion(range.MinimumNumber, range.MaximumNumber),
            _ => throw new InvalidOperationException($"Unhandled exception: '{operation}' is not valid")
        };
    }

    private MathsQuestion GenerateMixedMathsQuestion(int minRange, int maxRange)
    {
        int choice = rng.Next(0, 4);

        return choice switch

        {
            0 => GenerateAdditionQuestion(minRange, maxRange),
            1 => GenerateSubtractionQuestion(minRange, maxRange),
            2 => GenerateMultiplicationQuestion(minRange, maxRange),
            3 => GenerateDivisionQuestion(minRange, maxRange),
            _ => throw new InvalidOperationException($"This value '{choice}' should not exist")

        };
    }

    private MathsQuestion GenerateAdditionQuestion(int minRange, int maxRange)
    {
        int firstNumber = rng.Next(minRange, maxRange + 1);
        int secondNumber = rng.Next(minRange, maxRange + 1);
        int correctAnswer = firstNumber + secondNumber;
        return new MathsQuestion
        {
            FirstNumber = firstNumber,
            SecondNumber = secondNumber,
            Operation = Operation.Addition,
            CorrectAnswer = correctAnswer
        };
    }

    private MathsQuestion GenerateMultiplicationQuestion(int minRange, int maxRange)
    {
        int firstNumber = rng.Next(minRange, maxRange + 1);
        int secondNumber = rng.Next(minRange, maxRange + 1);
        int correctAnswer = firstNumber * secondNumber;
        return new MathsQuestion
        {
            FirstNumber = firstNumber,
            SecondNumber = secondNumber,
            Operation = Operation.Multiplication,
            CorrectAnswer = correctAnswer
        };
    }

    private MathsQuestion GenerateDivisionQuestion(int minRange, int maxRange)
    {
        int firstNumber = rng.Next(minRange, maxRange + 1);
        int secondNumber = rng.Next(minRange, maxRange + 1);

        while (firstNumber % secondNumber != 0 || firstNumber == secondNumber || secondNumber == 1)
        {
            firstNumber = rng.Next(minRange, maxRange + 1);
            secondNumber = rng.Next(minRange, maxRange + 1);
        }

        int correctAnswer = firstNumber / secondNumber;

        return new MathsQuestion
        {
            FirstNumber = firstNumber,
            SecondNumber = secondNumber,
            Operation = Operation.Division,
            CorrectAnswer = correctAnswer
        };
    }

    private MathsQuestion GenerateSubtractionQuestion(int minRange, int maxRange)
    {
        int firstNumber = rng.Next(minRange, maxRange + 1);
        int secondNumber = rng.Next(minRange, maxRange + 1);

        if (firstNumber - secondNumber < 0)
        {
            (firstNumber, secondNumber) = (secondNumber, firstNumber);

        }

        int correctAnswer = firstNumber - secondNumber;

        return new MathsQuestion
        {
            FirstNumber = firstNumber,
            SecondNumber = secondNumber,
            Operation = Operation.Subtraction,
            CorrectAnswer = correctAnswer
        };
    }


    private DifficultyConfig GetDifficultyRanges(Difficulty difficulty)
    {
        if (!_settings.Difficulties.TryGetValue(difficulty, out var ranges))
        {
            throw new InvalidOperationException(
                $"No difficulty seetings foind for '{difficulty}'"
            );
        }

        return ranges;
    }


}