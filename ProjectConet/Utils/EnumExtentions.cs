using static ProjectConet.Bot.Commands;

namespace ProjectConet.Utils
{
    internal static class EnumExtentions
    {
        public static string PrettifyCommand(this BotCommands command) 
        {
            return @$"/{command}";
        }

    }
}
