using System;

namespace Logger.Infra
{
    public interface ILog
    {
        void WriteEntry(LogEntry entry);

        /// <summary>
        /// Read all entries from startDate until now.
        /// </summary>
        LogEntry[] ReadEntries(DateTime startDate);

        void ClearLog();
    }
}