using System;

namespace Exercise_One
{
    public interface ILog
    {
        /// <summary>
        /// Write an entry to a log
        /// </summary>
        /// <param name="entry"></param>
        void WriteEntry(LogEntry entry);

        /// <summary>
        /// Read all the entries from the latest until startDate
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns>
        /// Array of LogEntry-s that holds the entries from the newest to startDate
        /// </returns>
        LogEntry[] ReadEntries(DateTime startDate);

        /// <summary>
        /// Clears the log
        /// </summary>
        void ClearLog();
    }
}