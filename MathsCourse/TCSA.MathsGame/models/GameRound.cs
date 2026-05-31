using TCSA.MathsGame.Enums;
using TCSA.MathsGame.Models;

namespace TCSA.MathsGame.Models;

public class GameRound
{
    public DateTime PlayedAt = DateTime.Now;
    public Enums.Operation Operation;
    public Enums.Difficulty Difficulty;
    public List<MathsQuestion> MathsQuestions = new();

    public int Score => MathsQuestions.Count(question => question.IsCorrect);

}