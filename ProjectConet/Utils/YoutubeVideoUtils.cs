using Conet.Utils;
using ProjectConet.Converter;
using ProjectConet.VideoDownload;
using System;
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
            try
            {
                Task.Run(() => converter.ConvertVideoToAudio(fileInput, fileOutput));
            }
            catch (Exception ex)
            {
                throw;
            }
            return fileOutput;
        }
    }
}
