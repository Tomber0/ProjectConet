namespace ProjectConet.VideoDownload
{

    abstract class VideoDownloader
    {
        public abstract Task<string> Download(string url, string? fileUrl, string? fileNewName);

        public abstract void Convert(string filePath);
    }
}
