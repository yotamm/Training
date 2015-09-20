using System;
using System.IO;
using Logger.Log_Types.Using;


namespace Logger
{
    public abstract class Logger : ILog
    {

        private readonly string _filePath;
        protected readonly int LogLimit;
        protected int CurrentEntry = 0;

        public string FilePath
        {
            get { return _filePath; }
        }

        protected Logger(string fileName, int limit)
        {
            ClearLog();
            LogLimit = limit;
            _filePath = $"{Directory.GetCurrentDirectory()}\\{fileName}";
        }

        public abstract void ClearLog();
        public abstract LogEntry[] ReadEntries(DateTime startDate);
        public abstract void WriteEntry(LogEntry entry);
    }
}

