using TCSA.MathsGame.Enums;

namespace TCSA.MathsGame.Models;



public class MathsQuestion
{
    public int FirstNumber { get; init; }
    public int SecondNumber { get; init; }

    public Operation Operation { get; init; }
    public int CorrectAnswer { get; init; }
    public int? UserAnswer { get; set; } = null;

    public bool IsCorrect => UserAnswer == CorrectAnswer;

    public override string ToString()
    {
        var op = OperatorSymbol();
        return $"{FirstNumber} {op} {SecondNumber} =";
    }

    private string OperatorSymbol()
    {
        return Operation switch

        {
            Operation.Addition => "+",
            Operation.Subtraction => "-",
            Operation.Multiplication => "*",
            Operation.Division => @"\",
            _ => throw new InvalidOperationException($"'{Operation}' is not a valid operation")
        };
    }
}