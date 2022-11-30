using Conet.Utils;
using ProjectConet.Converter;
using ProjectConet.VideoDownload;
using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ProjectConet.Utils
{
    internal static class YoutubeVideoUtils
    {
        public static string DownloadVideo(string url, string fileName)
        {
            VideoDownloader videoDownloader = new VideoDownloaderFromYoutube();
            var video = Task.Run(() => videoDownloader.DownloadVideoAsync(url, fileName)).Result;
            return video;
        }

        public static string ConvertVideo(string fileInput, string fileOutput)
        {
            FormatConverter converter = new YtVideoConverter();
            string audioFile = string.Empty;
            try
            {
                audioFile = Task.Run(() => converter.ConvertVideoToAudio(fileInput, fileOutput)).Result;
            }
            catch (Exception ex)
            {
                throw;
            }
            return audioFile;
        }

        public static Message UploadAudio(string filePath, ITelegramBotClient botClient, ChatId chatId)
        {
            Message message = new Message();
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                message = botClient.SendAudioAsync(chatId, new Telegram.Bot.Types.InputFiles.InputOnlineFile(fs)).Result;
            }
            return message;
        }
    }
}
