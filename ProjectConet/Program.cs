// See https://aka.ms/new-console-template for more information
using ProjectConet.Bot;
using ProjectConet.Logging;
Logger.Instance.Info("start");
string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config","token.json");
string tokenName = "token";
Bot telegamBot = new TelegramBot(fileName, tokenName);
telegamBot.StartBot();
Console.ReadLine();
/*въебать бота 
    реализовать токен и команды
    реализовать логику по которой бот добавляет файлы
*/