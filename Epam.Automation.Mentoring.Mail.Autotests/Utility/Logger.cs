using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;

namespace Epam.Automation.Mentoring.Mail.Autotests.Utility
{
    public static class Logger
    {
        private static ILog log = LogManager.GetLogger(typeof(Logger));

        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo(@"C:\Users\nrcos\source\repos\Automated Testing Mentoring Program [2020Q2 RU]\Epam.Automation.Mentoring.Mail.Autotests\log4net.config"));

        }
    }
}
