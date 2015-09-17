using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Targil_One;

namespace Exercise_One
{
    public class CsvFileLog : ILog
    {
        private readonly string _filePath;
        //private StreamWriter _stream;
        private const string FileTitle = "Severity,Time,Message";

        public string FilePath
        {
            get {  return _filePath;}
        }
        public CsvFileLog(string fileName)
        {
            _filePath = Directory.GetCurrentDirectory() + "\\" + fileName + ".csv";
            ClearLog();
        }

        public void WriteEntry(LogEntry entry)
        {
            try
            {
                File.AppendAllText(FilePath, string.Format("{0},{1},\"{2}\"", entry.Severity.ToString(), entry.Time.ToString(),
                    entry.Message));
                File.AppendAllText(FilePath, "\n");
             //   _stream.WriteLine(string.Format("{0},{1},\"{2}\"", entry.Severity.ToString(), entry.Time.ToString(),
               //     entry.Message));
            }
            catch (Exception e)
            {
                throw new NoLogDefinedException(_filePath);
            }
        }

        public LogEntry[] ReadEntries(DateTime date)
        {
            string[] lines;
            try
            {
                
                lines = File.ReadAllLines(_filePath);
            }
            catch (Exception e)
            {
                throw new NoLogDefinedException(_filePath);
            }
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
            File.Delete(_filePath);
            File.AppendAllText(FilePath, FileTitle);
            File.AppendAllText(FilePath, "\n");
            // _stream.WriteLine(FileTitle);
        }
    }
}