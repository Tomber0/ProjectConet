using MediaToolkit;
using MediaToolkit.Model;

namespace ProjectConet.Converter
{
    internal class YtVideoConverter : FormatConverter
    {
        /// <summary>
        /// converts videofile into audio format
        /// </summary>
        /// <param name="inputFilePath">input filename</param>
        /// <param name="outputFilePath">if null: will give random name</param>
        /// <returns></returns>
        public override string ConvertVideoToAudio(string inputFilePath,string outputFilePath)
        {
            var inputFile = new MediaFile { Filename = inputFilePath };
            var outputFile = new MediaFile { Filename = $"{outputFilePath}" };
            using (var engine = new Engine()) 
            {
                engine.GetMetadata(inputFile);
                engine.Convert(inputFile, outputFile);
            }
            return outputFile.Filename;
        }
    }
}
