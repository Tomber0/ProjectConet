using System.Text.RegularExpressions;

namespace ProjectConet.Utils
{
    internal static class StringExtensions
    {
        public static string GetMainUrlPart(this string baseUrl)
        {
            var replacement = "";
            string newUrl = baseUrl;
            Regex regex = new Regex(@$"(?>&).+");
            newUrl = regex.Replace(baseUrl, replacement);
            return newUrl;
        }
    }
}
