using System;
using System.Configuration;
using System.IO;
using Logger;
using Logger.Log_Types;
using Logger.Log_Types.Using;


namespace Exercise_One
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit;
            int.TryParse(ConfigurationManager.AppSettings["Log Limit"], out limit);
            string logTypeValue = ConfigurationManager.AppSettings["Log Type"];
            ILog log;
            DateTime logStartTime = DateTime.Now;
            switch (logTypeValue)
            {
                case "CSV":
                    log = new CsvFileLog(limit);
                    break;
                case "Encrypted CSV":
                    log = new EncryptedCsvFileLog(limit);
                    break;
                case "Event Log":
                    log = new EventLog();
                    break;
                default:
                    throw new NoLogDefinedException("The log file is not defined in the config file");
            }
            string line;
            bool exit = false;
            while (!exit)
            {
                line = Console.ReadLine();
                switch (line)
                {
                    case "a":
                        try
                        {
                            log.WriteEntry(new LogEntry(Severity.Information, "Blink your right eye"));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadLine();
                            exit = true;
                        }
                        break;
                    case "b":
                        try
                        {
                            log.WriteEntry(new LogEntry(Severity.Information, "Blink your left eye"));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadLine();
                            exit = true;
                        }
                        break;
                    case "c":
                        try
                        {
                            LogEntry[] entries = log.ReadEntries(logStartTime);
                            foreach (LogEntry logEntry in entries)
                            {
                                Console.WriteLine(logEntry.ToString());
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadLine();
                            exit = true;
                        }
                        break;
                    case "d":
                        exit = true;
                        break;
                }
            }
        }
    }
}
