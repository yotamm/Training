using System;
using System.Collections.Generic;
using System.IO;
using Logger.Log_Types.Using;

namespace Logger.Log_Types
{
    public class CsvFileLog : Logger
    {
        private const string FileTitle = "Severity,Time,Message\n";


        public CsvFileLog(int limit) : base("CSVLog.csv", limit)
        {
        }

        public override void WriteEntry(LogEntry entry)
        {
            try
            {
                if (CurrentEntry != LogLimit)
                {
                    File.AppendAllText(FilePath, GenerateEntryLine(entry) + "\n");
                    CurrentEntry++;
                }
                else
                {
                    throw new LogIsFullException("Log Limit Reached. Please Clear The Log");
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
        }

        protected string GenerateEntryLine(LogEntry entry)
        {
            return $"{entry.Severity},{entry.Time},\"{entry.Message}\"";
        }
        
        public override LogEntry[] ReadEntries(DateTime startDate)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(FilePath);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
            return EntryExtraction(lines, startDate);

        }

        protected LogEntry[] EntryExtraction(string[] lines, DateTime startDate)
        {
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

        public override void ClearLog()
        {
            File.Delete(FilePath);
            File.AppendAllText(FilePath, FileTitle);
        }
    }
}