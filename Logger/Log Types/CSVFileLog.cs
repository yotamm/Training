using System;
using System.Collections.Generic;
using System.IO;
using Logger.Exceptions;
using Logger.Infra;

namespace Logger.Log_Types
{
    public class CsvFileLog : ILog
    {
        private const string FileTitle = "Severity,Time,Message\n";

        protected readonly int LogLimit;
        protected int EntryCounter;

        public string FilePath { get; }

        public CsvFileLog(int limit)
        {
            FilePath = $"{Directory.GetCurrentDirectory()}\\CSVLog.csv";
            ClearLog();
            LogLimit = limit;
        }

        public void WriteEntry(LogEntry entry)
        {
            if (EntryCounter < LogLimit)
            {
                string line = GenerateEntryLine(entry);
                File.AppendAllText(FilePath, line + "\n");
                EntryCounter++;
            }
            else
            {
                throw new LogIsFullException("Log Limit Reached. Please Clear The Log");
            }
        }

        public LogEntry[] ReadEntries(DateTime startDate)
        {
            var lines = File.ReadAllLines(FilePath);

            List<LogEntry> toReturn = new List<LogEntry>();
            for (int i = lines.Length - 1; i >= 1; i--)
            {
                var line = lines[i];

                line = GetCSVString(line);

                string[] seperated = line.Split(new[] { ',' }, 3);
                Severity severity;
                Enum.TryParse(seperated[0], out severity);
                DateTime time;
                DateTime.TryParse(seperated[1], out time);
                LogEntry entry = new LogEntry { Severity = severity, Message = seperated[2], Time = time };
                if (startDate > entry.Time)
                {
                    break;
                }
                toReturn.Add(entry);
            }
            return toReturn.ToArray();
        }

        public void ClearLog()
        {
            File.Delete(FilePath);
            File.AppendAllText(FilePath, FileTitle);
        }

        protected virtual string GenerateEntryLine(LogEntry entry)
        {
            return $"{entry.Severity},{entry.Time},\"{entry.Message}\"";
        }

        protected virtual string GetCSVString(string line)
        {
            return line;
        }
    }
}