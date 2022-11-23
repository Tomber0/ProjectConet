namespace ProjectConet.VideoDownload
{

    abstract class VideoDownloader
    {
        public abstract Task<string> DownloadVideoAsync(string url, string filePath);
    }
}
