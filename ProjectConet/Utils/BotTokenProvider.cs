namespace ProjectConet.Utils
{
    internal static class BotTokenProvider
    {
        public static string GetTokenFromFileByKey(string path, string key)
        {
            return JsonUtils.GetValueByKey(path, key);
        }
    }
}
