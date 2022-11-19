using ProjectConet.Bot.Messages;
using System;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
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

        public async override Task HandleErrorsAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
            if (exception is ApiRequestException apiRequestException)
            {
                await botClient.SendTextMessageAsync(123, apiRequestException.ToString());
            }
        }

        public async override Task HandleUpdatesAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is Message message)
            {
                Logging.Logger.Instance.Info($"Message - {message.Text}");
            }
        }

        public override void StartBot()
        {
            var cancellationToken = new CancellationTokenSource();
            var token = cancellationToken.Token;
            var reciveOptions = new ReceiverOptions() { AllowedUpdates = { } };
            string botToken = null;
        }

        public override void StopBot()
        {
            throw new NotImplementedException();
        }
    }
}
