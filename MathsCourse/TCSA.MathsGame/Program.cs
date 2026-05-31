using TCSA.MathsGame.Config;
using TCSA.MathsGame.Services;
using TCSA.MathsGame.UI;

var config = new GameSettings();
var questionGenerator = new MathsQuestionGenerator(config);
var historyService = new GameHistoryService();
var historyUI = new HistoryUI(historyService);
var gameUI = new GameUI(questionGenerator, historyService);
var menuUI = new MenuUI(gameUI, historyUI);

menuUI.Run();