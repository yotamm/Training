using System;
using System.Collections.Generic;
using System.IO;

namespace Exercise_One
{
    public class CsvFileLog : Logger
    {
        private const string FileTitle = "Severity,Time,Message\n";
        public string FilePath { get; }


        public CsvFileLog(string fileName)
        {
            FilePath = Directory.GetCurrentDirectory() + "\\" + fileName + ".csv";
            ClearLog();
        }

        public override void WriteEntry(LogEntry entry)
        {
            try
            {
                File.AppendAllText(FilePath, $"{entry.Severity},{entry.Time},\"{entry.Message}\"\n");
            }
            catch (Exception e)
            {
                throw new NoLogDefinedException(FilePath);
            }
        }
        
        public override LogEntry[] ReadEntries(DateTime startDate)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(FilePath);
            }
            catch (Exception)
            {
                throw new NoLogDefinedException(FilePath);
            }

            List<LogEntry> toReturn = new List<LogEntry>();
            for (int i = lines.Length - 1; i >= 1; i--)
            {
                string[] seperated = lines[i].Split(new[] { ',' }, 3);
                Severity severity;
                Enum.TryParse(seperated[0], out severity);
                DateTime time;
                DateTime.TryParse(seperated[1], out time);
                LogEntry current = new LogEntry(severity, seperated[2], time);
                if (startDate.CompareTo(current.Time) > 0)
                {
                    break;
                }
                toReturn.Add(current);
            }
            return toReturn.ToArray();
        }

        
    }
}