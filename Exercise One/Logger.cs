using System;
using System.IO;

namespace Exercise_One
{
    public abstract class Logger : ILog
    {
        private const string _fileTitle = "Severity,Time,Message\n";
        private string _filePath; //TODO get the log file from the config

        public virtual void ClearLog()
        {
            File.Delete(_filePath);
            File.AppendAllText(_filePath, _fileTitle);
        }

        public abstract LogEntry[] ReadEntries(DateTime startDate);
        public abstract void WriteEntry(LogEntry entry);
    }
}