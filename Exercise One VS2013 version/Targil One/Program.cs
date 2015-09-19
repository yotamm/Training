using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_One
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string RIGHT_BLINK = "Right eye was blinked";
            string LEFT_BLINK = "Left eye was blinked";
            string line;
            char cur_char;
            LogEntry entry;
            CsvFileLog log1 = new CsvFileLog("log1");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Choose a,b,c or d:");
                Console.WriteLine("a. Blink your right eye");
                Console.WriteLine("b. Blink your left eye");
                Console.WriteLine("c. Administration");
                Console.WriteLine("d. Exit");


                line = Console.ReadLine();

                switch (line)
                {
                    case "a":
                        try
                        {
                            entry = new LogEntry(Severity.Information, RIGHT_BLINK);
                            log1.WriteEntry(entry);
                            Console.WriteLine("Right Eye was blinked");
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
                            entry = new LogEntry(Severity.Information, LEFT_BLINK);
                            log1.WriteEntry(entry);
                            Console.WriteLine("Left Eye was blinked");

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
                            LogEntry[] entries = log1.ReadEntries(File.GetCreationTime(log1.FilePath).Date);
                            for (int i = 0; i < entries.Length; i++)
                            {
                                Console.WriteLine(entries[i].ToString());
                            }
                            break;
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


            Console.ReadLine();
        }
    }
}
