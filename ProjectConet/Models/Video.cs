namespace ProjectConet.Models
{
    internal class Video
    {
        public string Title { get; set; }
        public byte[] Data { get; set; }
        public string FilePath { get; set; }

        public Video() { }

        public Video(string title, string filePath) : this()
        {
            Title = title;
            FilePath = filePath;
        }

        public Video(string title, byte[] data, string filePath) : this(title, filePath)
        {
            Data = data;
        }


    }
}
