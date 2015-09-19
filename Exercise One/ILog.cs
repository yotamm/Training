using System;

namespace Exercise_One
{
    public interface ILog
    {
        void WriteEntry(LogEntry entry);
        LogEntry[] ReadEntries(DateTime startDate);
        void ClearLog();
    }
}