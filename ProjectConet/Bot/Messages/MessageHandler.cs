using ProjectConet.Utils;
using ProjectConet.VideoDownload;
using Telegram.Bot.Types;

namespace ProjectConet.Bot.Messages
{
    internal class MessageHandler
    {
        public MessageHandler() { }

        public string OnMessage(Message message) 
        {
            string response = "";
            if (message != null && message.Text.IsYoutubeLink()) 
            {
                VideoDownloader videoDownloader = new VideoDownloaderFromYoutube();
                var video = Task.Run(()=> videoDownloader.Download(message.Text, null, null)).Result;
            }
            return response;
        }

    }
}
