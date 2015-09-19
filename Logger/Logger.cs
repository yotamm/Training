using System;
using System.IO;
using Logger.Log_Types.Using;


namespace Logger
{
    public abstract class Logger : ILog
    {

        private readonly string _filePath; //TODO get the log file from the config

        public string FilePath
        {
            get { return _filePath; }
        }

        protected Logger(string fileName)
        {
            ClearLog();
            _filePath = $"{Directory.GetCurrentDirectory()}\\{fileName}";
        }

        public abstract void ClearLog();
        public abstract LogEntry[] ReadEntries(DateTime startDate);
        public abstract void WriteEntry(LogEntry entry);
    }
}

