using VideoLibrary;


namespace ProjectConet.VideoDownload
{
    internal class VideoDownloaderFromYoutube:VideoDownloader
    {
        public async override Task<string> Download(string url, string? fileDirUrl, string? newFileName)
        {
            var youTube = YouTube.Default;
            YouTubeVideo video = null;
            try
            {
                video = await youTube.GetVideoAsync(url);
            }
            catch (Exception ex)
            {
                Logging.Logger.Instance.Error("Can't download video");
                Logging.Logger.Instance.Error($"Message: {ex}");
            }
            var videoPath = $"{fileDirUrl ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"videos")}\\" + $"{newFileName ?? Guid.NewGuid().ToString()}" + ".mp4";
            if (video is not null)
            {
                try
                {
                    await File.WriteAllBytesAsync($"{videoPath}", video?.GetBytes());
                    return videoPath;
                }
                catch (Exception ex)
                {
                    Logging.Logger.Instance.Error("Can't save video");
                    Logging.Logger.Instance.Error($"Message: {ex}");
                }
            }
            return videoPath;
        }

        public override void Convert(string path)
        {
        }
    }
}
