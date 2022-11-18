using Telegram.Bot.Types;
using Telegram.Bot;

namespace ProjectConet.Bot
{
    internal abstract class Bot
    {
        public abstract void StartBot();
        
        public abstract void StopBot();

        public abstract Task HandleUpdatesAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);

        public abstract Task HandleErrorsAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
    }
}
