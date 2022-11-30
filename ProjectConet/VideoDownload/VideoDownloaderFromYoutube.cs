using Conet.Utils;
using ProjectConet.Utils;
using VideoLibrary;


namespace ProjectConet.VideoDownload
{
    internal class VideoDownloaderFromYoutube:VideoDownloader
    {
        public async override Task<Models.Video> DownloadVideoAsync(string url, string videoPath)
        {
            if (url == String.Empty || !url.IsYoutubeLink())
            {
                throw new Exception("Url text is empty or not a link!");
            }
            var mainUrlPart = url.GetMainUrlPart();
            var youTube = YouTube.Default;
            var title = string.Empty;
            YouTubeVideo video = null;
            try
            {
                video = await youTube.GetVideoAsync(mainUrlPart);
            }
            catch (Exception ex)
            {
                throw;
            }
            if (video is not null)
            {
                try
                {
                    using (FileStream fs = new FileStream(videoPath, FileMode.OpenOrCreate))
                    {
                        await fs.WriteAsync(video.GetBytes(), 0, video.GetBytes().Length);
                    }
                }
                catch (Exception ex)
                {
                    videoPath = null;
                    throw;
                }
            }
            return new Models.Video(video.Title, videoPath);
        }

    }
}
