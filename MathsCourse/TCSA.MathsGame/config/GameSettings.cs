using TCSA.MathsGame.Enums;

namespace TCSA.MathsGame.Config;

public class GameSettings
{

    public int RoundsPerGame = 5;
    public IReadOnlyDictionary<Difficulty, DifficultyConfig> Difficulties =
        new Dictionary<Difficulty, DifficultyConfig>
        {
            [Difficulty.Easy] = new DifficultyConfig { MinimumNumber = 1, MaximumNumber = 10 },
            [Difficulty.Medium] = new DifficultyConfig { MinimumNumber = 1, MaximumNumber = 50 },
            [Difficulty.Hard] = new DifficultyConfig { MinimumNumber = 1, MaximumNumber = 100 },
        };


}

public class DifficultyConfig
{
    public int MinimumNumber { get; init; }
    public int MaximumNumber { get; init; }
}