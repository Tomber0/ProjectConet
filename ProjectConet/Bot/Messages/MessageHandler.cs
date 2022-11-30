using Conet.Utils;
using ProjectConet.Utils;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ProjectConet.Bot.Messages
{
    internal class MessageHandler
    {
        private ITelegramBotClient _botClient;
        public MessageHandler(ITelegramBotClient botClient) { botClient = _botClient; }
        public async Task<string?> OnMessage(Message message) 
        {
            string? response = null;
            if (message != null && message.Text.IsYoutubeLink()) 
            {
                if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "audios")))
                {
                    Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "audios"));
                }
                var audioPath = $"{Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "audios"), $"{TimeUtils.CurrentTime}.mp3")}";
                if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "videos")))
                {
                    Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "videos"));
                }
                var videoPath = $"{Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "videos"), $"{TimeUtils.CurrentTime}.mp4")}";
                YoutubeVideoUtils.DownloadVideo(message.Text, videoPath);
                var path = YoutubeVideoUtils.ConvertVideo(videoPath, audioPath);
                //YoutubeVideoUtils.UploadAudio(path, _botClient, message.Chat);
                response = path;
            }
            return response;
        }

    }
}
