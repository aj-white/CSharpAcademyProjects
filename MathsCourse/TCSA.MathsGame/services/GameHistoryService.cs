using TCSA.MathsGame.Models;

namespace TCSA.MathsGame.Services;

public class GameHistoryService
{
    private readonly List<GameRound> _gameHistory = new();

    public void Save(GameRound gameRound)
    {
        _gameHistory.Add(gameRound);
    }

    public IReadOnlyList<GameRound> GetGameHistory()
    {
        return _gameHistory.AsReadOnly();
    }
}