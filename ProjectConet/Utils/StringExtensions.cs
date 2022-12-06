using System.Text.RegularExpressions;

namespace ProjectConet.Utils
{
    internal static class StringExtensions
    {
        public static string GetMainUrlPart(this string baseUrl)
        {
            var replacement = "";
            Regex regex = new Regex(@$"(?>&).+");
            string newUrl = regex.Replace(baseUrl, replacement);
            return newUrl;
        }

        public static bool IsYoutubeLink(this string url) 
        {
            Regex regex = new Regex(@".*youtu+.+");
            return regex.IsMatch(url);
        }
    }
}
