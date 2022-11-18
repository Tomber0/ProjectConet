namespace ProjectConet.Bot
{
    internal static class Commands
    {
        public enum BotCommands 
        {
            start,
            help
        }

        public static string Command(BotCommands command) 
        {
            return @$"/{command}";
        }
    }
}
