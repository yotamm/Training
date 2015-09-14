using System;
using System.Security.Cryptography.X509Certificates;

namespace Exercise_One
{
    public interface ILog
    {
        void WriteEntry(LogEntry entry);
        string[] ReadEntries(DateTime date);
        void ClearLog();
    }
}