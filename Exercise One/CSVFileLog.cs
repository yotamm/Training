using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercise_One
{
    public class CsvFileLog : ILog
    {
        private static readonly string FilePath = Directory.GetCurrentDirectory() + "CsvFileLog" + ".csv";
        private StreamWriter _stream = File.CreateText(FilePath);
        private const string FileTitle = "Severity,Time,Message";
        

        public CsvFileLog()
        {
            ClearLog();
        }

        public void WriteEntry(LogEntry entry)
        {
            _stream.WriteLine($"{entry.Severity.ToString()},{entry.Time.ToString()},\"{entry.Message}\"");
        }

        public LogEntry[] ReadEntries(DateTime date)
        {
            string[] lines = File.ReadAllLines(FilePath);
            List<LogEntry> toReturn = new List<LogEntry>();
            for (int i = lines.Length - 1; i >= 1; i--)
            {
                LogEntry current = new LogEntry(lines[i]);
                if (date.CompareTo(current.Time)>0)
                {
                    break;
                }
                toReturn.Add(current);
            }
            return toReturn.ToArray();
        }

        public void ClearLog()
        {
            File.Delete(FilePath);
            _stream = File.CreateText(FilePath + ".csv");
            _stream.WriteLine(FileTitle);
        }
    }
}