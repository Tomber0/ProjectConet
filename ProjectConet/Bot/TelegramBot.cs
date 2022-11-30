using Conet.Utils;
using ProjectConet.Bot.Messages;
using ProjectConet.Utils;
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

        public TelegramBot(string tokenFileName, string tokenName)
        {
            _fileName = tokenFileName;
            _tokenName = tokenName;
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
                Logging.Logger.Instance.Info($"Recived message from {message.Chat.Id} : {message.Text}");
                MessageHandler messageHandler = new MessageHandler(botClient);
                if (message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                {
                    var filePath = Task.Run(() => messageHandler.OnMessage(message)).Result;
                    if (filePath != null) 
                    {
                        Logging.Logger.Instance.Info($"Sending audio message to {message.Chat.Id}");
                        var m = YoutubeVideoUtils.UploadAudio(filePath, botClient, message.Chat);
                        Logging.Logger.Instance.Info($"Sent audio message to {message.Chat.Id}, audioId: {m.Audio?.FileId} ");
                    }
                }
                else
                {
                    var response = "only text";
                    Logging.Logger.Instance.Info($"Sending response message to {message.Chat.Id} : {response}");
                    await botClient.SendTextMessageAsync(message.Chat, response);
                }
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
