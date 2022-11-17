using System.Text.RegularExpressions;

namespace ProjectConet.Utils
{
    internal static class StringExtensions
    {
        public static string GetMainUrlPart(this string baseUrl) 
        {
            Regex regex = new Regex(@$"^.+?(?=&)");
            var matchedUrl = regex.Match(baseUrl);
            return matchedUrl.Value;
        }
    }
}
