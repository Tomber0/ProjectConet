namespace ProjectConet.VideoDownload
{

    abstract class VideoDownloader
    {
        public abstract Task<Models.Video> DownloadVideoAsync(string url, string filePath);
    }
}
