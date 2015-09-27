using System.Configuration;
using Logger.Exceptions;
using Logger.Infra;
using Logger.Log_Types;

namespace Logger
{
    public sealed class Logger
    {
        public ILog Log { get; }

        public static Logger Instance { get; } = new Logger();

        static Logger()
        {
        }

        Logger()
        {
            int limit;
            int.TryParse(ConfigurationManager.AppSettings["Log Limit"], out limit);
            string logTypeValue = ConfigurationManager.AppSettings["Log Type"];
            switch (logTypeValue)
            {
                case "CSV":
                    Log = new CsvFileLog(limit);
                    break;
                case "Encrypted CSV":
                    Log = new EncryptedCsvFileLog(limit);
                    break;
                case "Event Log":
                    Log = new EventLog();
                    break;
                default:
                    throw new NoLogDefinedException("The log file is not defined in the config file");
            }
        }
        
    }
}