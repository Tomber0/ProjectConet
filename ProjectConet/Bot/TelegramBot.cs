using ProjectConet.Bot.Messages;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ProjectConet.Bot
{
    internal class TelegramBot : Bot
    {
        private TelegramBotClient _telegramBotClient;
        private CancellationTokenSource _cancellTokenSource;
        private MessageHandler _messageHandler;
        
        public TelegramBotClient TelegramBotClient
        {
            get
            {
                return _telegramBotClient;
            }
        }
        
        public CancellationTokenSource CancellationToken => _cancellTokenSource;

        public TelegramBot(MessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        public override Task HandleErrorsAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task HandleUpdatesAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override void StartBot()
        {
            throw new NotImplementedException();
        }

        public override void StopBot()
        {
            throw new NotImplementedException();
        }


    }
}
