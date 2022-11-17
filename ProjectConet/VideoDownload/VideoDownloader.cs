namespace ProjectConet.VideoDownload
{

    abstract class VideoDownloader
    {
        public abstract void Download(string url, string fileUrl, string fileNewName);

        public abstract void Convert(string filePath);
    }
}
