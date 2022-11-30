namespace ProjectConet.Models
{
    internal class Audio
    {
        public string Title { get; set; }
        public byte[] Data { get; set; }
        public string FilePath { get; set; }

        public Audio() { }

        public Audio(string title, string filePath) : this() 
        {
            Title = title;
            FilePath = filePath;
        }

        public Audio(string title, byte[] data, string filePath) : this(title, filePath)
        {
            Data = data;
        }

    }
}
