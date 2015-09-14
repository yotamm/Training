using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercise_One
{
    public class CsvFileLog : ILog
    {
        private static readonly string FilePath = Directory.GetCurrentDirectory() + "CsvFileLog" + ".csv";
        private StreamWriter _stream = File.CreateText(FilePath + ".csv");
        private const string _fileTitle = "Severity,Time,Message";
        

        public CsvFileLog()
        {
            ClearLog();
        }

        public void WriteEntry(LogEntry entry)
        {
            _stream.WriteLine($"{entry.Severity.ToString()},{entry.Time.ToString()},\"{entry.Message}\"");
        }

        public string[] ReadEntries(DateTime date)
        {
            string[] lines = File.ReadAllLines(FilePath);
            List<string> toReturn = lines.ToList();
            for (int i = lines.Length - 1; i >= 0; i--)
            {
                
            }
        }

        public void ClearLog()
        {
            _stream.WriteLine(_fileTitle);
        }
    }
}