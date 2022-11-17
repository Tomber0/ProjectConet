using VideoLibrary;


namespace ProjectConet.VideoDownload
{
    internal class VideoDownloaderFromYoutube:VideoDownloader
    {
        public async override void Download(string url, string fileDirUrl, string newFileName)
        {
            var youTube = YouTube.Default;
            var video = await youTube.GetVideoAsync(url); 
            var videoPath = $"{fileDirUrl}\\" + $"{newFileName}" + ".mp4";
            await File.WriteAllBytesAsync($"{videoPath}", video.GetBytes());
        }

        public override void Convert(string path)
        {
        }
    }
}
