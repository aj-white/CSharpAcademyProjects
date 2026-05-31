using System.Dynamic;
using System.Runtime.InteropServices;
using TCSA.MathsGame.Enums;

namespace TCSA.MathsGame.Config;

public class GameSettings
{

    public int RoundsPerGame { get; private set; }
    public IReadOnlyDictionary<Difficulty, DifficultyConfig> Difficulties { get; private set; }

    private GameSettings()
    {
        Difficulties = new Dictionary<Difficulty, DifficultyConfig>().AsReadOnly();
    }

    public class Builder
    {
        private int _roundPerGame = 5;
        private readonly Dictionary<Difficulty, DifficultyConfig> _difficultyRanges = new();

        public static Builder Create() => new();

        public Builder WithDefaultSettings()
        {
            _roundPerGame = 5;
            _difficultyRanges[Difficulty.Easy] = new DifficultyConfig { MinimumNumber = 1, MaximumNumber = 10 };
            _difficultyRanges[Difficulty.Medium] = new DifficultyConfig { MinimumNumber = 10, MaximumNumber = 50 };
            _difficultyRanges[Difficulty.Hard] = new DifficultyConfig { MinimumNumber = 50, MaximumNumber = 100 };
            return this;
        }

        public Builder WithRoundsPerGane(int numberRounds)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberRounds);

            _roundPerGame = numberRounds;
            return this;
        }

        public Builder WithEasyDifficultyRange(int min, int max)
        {
            return WithDifficultyRanges(Difficulty.Easy, min, max);
        }

        public Builder WithMediumDifficultyRange(int min, int max)
        {
            return WithDifficultyRanges(Difficulty.Medium, min, max);
        }

        public Builder WithHardDifficultyRange(int min, int max)
        {
            return WithDifficultyRanges(Difficulty.Hard, min, max);
        }

        private Builder WithDifficultyRanges(Difficulty difficulty, int min, int max)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(min);
            ArgumentOutOfRangeException.ThrowIfLessThan(max, min);
            _difficultyRanges[difficulty] = new DifficultyConfig { MinimumNumber = min, MaximumNumber = max };
            return this;
        }

        public GameSettings Build()
        {
            if (!_difficultyRanges.ContainsKey(Difficulty.Easy) || !_difficultyRanges.ContainsKey(Difficulty.Medium) || !_difficultyRanges.ContainsKey(Difficulty.Hard))
            {
                throw new InvalidOperationException("All difficulty ranges must be set before building. Call WithDefaults() or set each range explicitly.");
            }

            return new GameSettings { RoundsPerGame = _roundPerGame, Difficulties = _difficultyRanges.AsReadOnly() };

        }
    }
}

public class DifficultyConfig
{
    public int MinimumNumber { get; init; }
    public int MaximumNumber { get; init; }
}

