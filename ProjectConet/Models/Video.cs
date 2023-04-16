using YoutubeExplode.Common;

namespace ProjectConet.Models
{
    internal class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public byte[] Data { get; set; }
        public string FilePath { get; set; }

        public Video() { }

        public Video(string title,string author, string filePath) : this()
        {
            Author = author;
            Title = title;
            FilePath = filePath;
        }

        public Video(string title,string author, byte[] data, string filePath) : this(title,author, filePath)
        {
            Data = data;
        }


    }
}
