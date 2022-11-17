using NLog;

namespace ProjectConet.Logging
{
    internal class Logger
    {
        private static NLog.Logger? _logger;

        public static NLog.Logger Instance
        {
            get
            {
                if (_logger == null)
                {
                    LogManager.Configuration= new NLog.Config.XmlLoggingConfiguration(@"Config\NLog.config");
                    _logger = LogManager.GetLogger("Common");
                }
                return _logger;
            }

            private set
            {
                _logger = value;
            }
        }
    }
}
