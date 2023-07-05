using Microsoft.Extensions.Logging;

namespace WMIEventLoggerTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write something to log: ");
            var str = Console.ReadLine();

            Console.Write("\nWrite a log type: ");
            var logType = Console.ReadLine();

            var wmiLogger = new WMIEventLogger();

            switch (logType)
            {
                case "Information":
                    wmiLogger.LogInformation(str);
                    break;
                case "Error":
                    wmiLogger.LogError(str);
                    break;
                case "Warning":
                    wmiLogger.LogWarning(str);
                    break;
            }

            Console.ReadKey();
        }
    }
}