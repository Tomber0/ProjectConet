namespace Conet.Utils
{
    internal static class TimeUtils
    {
        public static string CurrentTime
        {
            get
            {
                return $"{DateTime.Now.Ticks}";
            }
        }
    }
}
