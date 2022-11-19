using VideoLibrary;


namespace ProjectConet.VideoDownload
{
    internal class VideoDownloaderFromYoutube:VideoDownloader
    {
        public async override void Download(string url, string fileDirUrl, string newFileName)
        {
            var youTube = YouTube.Default;
            object videoTask = null;
            try
            {
                videoTask = await youTube.GetVideoAsync(url); 
            }
            catch (Exception ex)
            {
                Logging.Logger.Instance.Error(ex.Message);
            }
            var videoPath = $"{fileDirUrl}\\" + $"{newFileName}" + ".mp4";
            try
            {
                await File.WriteAllBytesAsync($"{videoPath}", ((YouTubeVideo)videoTask).GetBytes());
            }
            catch (Exception ex)
            {
                Logging.Logger.Instance.Error(ex.Message);
            }
        }

        public override void Convert(string path)
        {
        }
    }
}
