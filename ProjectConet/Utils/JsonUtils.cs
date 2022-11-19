using Newtonsoft.Json;

namespace ProjectConet.Utils
{
    internal static class JsonUtils
    {
        public static string GetValueByKey(string path, string key) 
        {
            using (var reader = new StreamReader(path))
            {
                var jsonFile = reader.ReadToEnd();
                Dictionary<string, string> botTokens =  JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonFile);
                return botTokens[key];
            }
        }
    }
}
