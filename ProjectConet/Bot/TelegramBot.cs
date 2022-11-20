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
        private string _fileName = "token.json";
        private string _tokenName = "token";

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
                Logging.Logger.Instance.Error(apiRequestException.ToString());
                await botClient.SendTextMessageAsync(123, apiRequestException.ToString());
            }
        }

        public async override Task HandleUpdatesAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is Message message)
            {
                Logging.Logger.Instance.Info($"Message - {message.Text}");

                //process the message
            }
        }

        public override void StartBot()
        {

            _cancellTokenSource = new CancellationTokenSource();
            var token = _cancellTokenSource.Token;
            var reciveOptions = new ReceiverOptions() { AllowedUpdates = { } };
            string botToken = Utils.BotTokenProvider.GetTokenFromFileByKey(_fileName,_tokenName);
            _telegramBotClient = new TelegramBotClient(botToken);
            _telegramBotClient.StartReceiving(HandleUpdatesAsync, HandleErrorsAsync, reciveOptions, token);
        }

        public override void StopBot()
        {
            throw new NotImplementedException();
            //?
        }
    }
}
