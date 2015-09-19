using System;
using System.Configuration;
using System.IO;
using Logger.Log_Types;
using Logger.Log_Types.Using;


namespace Exercise_One
{
    class Program
    {
        static void Main(string[] args)
        {
            string logTypeValue = ConfigurationManager.AppSettings["Log Type"];
            Logger.Logger log;
            switch (logTypeValue)
            {
                case "CSV":
                    log = new CsvFileLog();
                    break;
                case "Encrypted CSV":
                    log = new EncryptedCsvFileLog();
                    break;
                case "Event Log":
                    log = new EventLog();
                    break;
                default:
                    log = new CsvFileLog();
                    break;
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
                            LogEntry[] entries = log.ReadEntries(File.GetCreationTime(log.FilePath).Date);
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
