using Microsoft.Extensions.DependencyInjection;
using TCSA.MathsGame.Config;
using TCSA.MathsGame.Services;
using TCSA.MathsGame.UI;

var config = GameSettings.Builder
    .Create()
    .WithRoundsPerGane(5)
    .WithEasyDifficultyRange(1, 10)
    .WithMediumDifficultyRange(10, 50)
    .WithHardDifficultyRange(50, 100)
    .Build();

var services = new ServiceCollection()
    .AddSingleton(config)
    .AddSingleton<GameHistoryService>()
    .AddSingleton<MathsQuestionGenerator>()
    .AddSingleton<HistoryUI>()
    .AddSingleton<GameUI>()
    .AddSingleton<MenuUI>()
    .BuildServiceProvider();

services.GetRequiredService<MenuUI>().Run();