using Conet.Utils;
using ProjectConet.Converter;
using ProjectConet.Utils;
using ProjectConet.VideoDownload;
using System;
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
                FormatConverter converter = new YtVideoConverter();
                if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "videos")))
                {
                    Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "videos"));
                }
                var videoPath = $"{Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "videos"), $"{TimeUtils.CurrentTime}.mp4")}";
                var video = Task.Run(()=> videoDownloader.DownloadVideoAsync(message.Text, videoPath)).Result;
                if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "audios")))
                {
                    Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "audios"));
                }
                var audioPath = $"{Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "audios"), $"{TimeUtils.CurrentTime}.mp3")}";
                try
                {
                    Task.Run(() => converter.ConvertVideoToAudio(video, audioPath));
                }
                catch (Exception ex)
                {
                    throw;
                }


            }
            return response;
        }

    }
}
