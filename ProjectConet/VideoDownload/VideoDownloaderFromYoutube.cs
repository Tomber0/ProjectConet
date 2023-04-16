using Conet.Utils;
using ProjectConet.Utils;
//using VideoLibrary;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;


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
            //var youTube = YouTube.Default;
            var title = string.Empty;
            YoutubeExplode.Videos.Video video = null;
            StreamManifest streamManifest = null;
            var youtube = new YoutubeClient();

            try
            {
                video = await youtube.Videos.GetAsync(url);
                streamManifest = await youtube.Videos.Streams.GetManifestAsync(url);

                //video = await youTube.GetVideoAsync(mainUrlPart);
            }
            catch (Exception ex)
            {
                throw;
            }
            if (video is not null)
            {
                try
                {
                    var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

                    var stream = await youtube.Videos.Streams.GetAsync(streamInfo);

                    await youtube.Videos.Streams.DownloadAsync(streamInfo, videoPath);

/*                    using (FileStream fs = new FileStream(videoPath, FileMode.OpenOrCreate))
                    {
                        var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

                        var stream = await youtube.Videos.Streams.GetAsync(streamInfo);

                        await youtube.Videos.Streams.DownloadAsync(streamInfo,fs.Name);

                        //await fs.WriteAsync(video.GetBytes(), 0, video.GetBytes().Length);
                    }
*/                }
                catch (Exception ex)
                {
                    videoPath = null;
                    throw;
                }
            }
            return new Models.Video(video.Title,video.Author.ChannelTitle, videoPath);
        }

    }
}
