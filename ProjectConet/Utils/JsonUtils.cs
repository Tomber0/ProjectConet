using Newtonsoft.Json;

namespace ProjectConet.Utils
{
    internal static class JsonUtils
    {
        public static string GetValueByKey(string path, string key) 
        {
            try
            {
                using (var reader = new StreamReader(path))
                {
                    var jsonFile = reader.ReadToEnd();
                    Dictionary<string, string> botTokens = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonFile);
                    return botTokens[key];
                }
            }
            catch (Exception ex)
            {
                Logging.Logger.Instance.Error($"Can't find json file: {path}\n with token name: {key}\n, make shure it exists in 'Config' directory");
                throw;
            }
        }
    }
}
