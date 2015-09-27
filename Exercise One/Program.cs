using System;
using Logger.Infra;



namespace Exercise_One
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog log = Logger.Logger.Instance.Log;
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
                            log.WriteEntry(new LogEntry() {Message = "Blink your right eye"});
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
                            log.WriteEntry(new LogEntry() {Message = "Blink your left eye"});
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
                            LogEntry[] entries = log.ReadEntries(DateTime.MinValue);
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
