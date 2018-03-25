using log4net;
using log4net.Config;

namespace BLL.Infrastructure
{
    /// <summary>
    /// Application events loger
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Getter to logger 
        /// </summary>
        public static ILog Log { get; } = LogManager.GetLogger("LOGGER");

        /// <summary>
        /// Configure logger
        /// </summary>
        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
