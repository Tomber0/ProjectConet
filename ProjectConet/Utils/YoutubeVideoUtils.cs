﻿using Conet.Utils;
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
        public static Models.Video DownloadVideo(string url, string fileName)
        {
            VideoDownloader videoDownloader = new VideoDownloaderFromYoutube();
            var video = Task.Run(() => videoDownloader.DownloadVideoAsync(url, fileName)).Result;
            return video;
        }

        public static Models.Audio ConvertVideo(Models.Video videoInput, string fileOutput)
        {
            FormatConverter converter = new YtVideoConverter();
            string audioFile = string.Empty;
            try
            {
                audioFile = Task.Run(() => converter.ConvertVideoToAudio(videoInput.FilePath, fileOutput)).Result;
            }
            catch (Exception ex)
            {
                throw;
            }
            return new Models.Audio(videoInput.Title, audioFile);
        }



        public static Message UploadAudio(Models.Audio audio, ITelegramBotClient botClient, ChatId chatId)
        {
            Message message = new Message();
            if (audio.FilePath == null) 
            {
                return botClient.SendTextMessageAsync(chatId, "not a link").Result;
            }
            using (FileStream fs = new FileStream(audio.FilePath, FileMode.Open))
            {
                message = botClient.SendAudioAsync(chatId, new Telegram.Bot.Types.InputFiles.InputOnlineFile(fs),title:$"{audio.Title}").Result;
            }
            return message;
        }

        public static Message UploadVideo(Models.Video video, ITelegramBotClient botClient, ChatId chatId)
        {
            Message message = new Message();
            if (video.FilePath == null) 
            {
                return botClient.SendTextMessageAsync(chatId, "not a link").Result;
            }
            using (FileStream fs = new FileStream(video.FilePath, FileMode.Open))
            {
                //message = botClient.SendVideoAsync(chatId, new Telegram.Bot.Types.InputFiles.InputOnlineFile(fs),)

                message = botClient.SendAudioAsync(chatId, new Telegram.Bot.Types.InputFiles.InputOnlineFile(fs),title:$"{video.Title}").Result;
            }
            return message;
        }
    }
}
