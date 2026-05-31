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

var questionGenerator = new MathsQuestionGenerator(config);
var historyService = new GameHistoryService();
var historyUI = new HistoryUI(historyService);
var gameUI = new GameUI(questionGenerator, historyService);
var menuUI = new MenuUI(gameUI, historyUI);

menuUI.Run();