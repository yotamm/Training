using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace Exercise_One
{
    public class EventLog : ILog
    {
        private static string source = "Exercise_One", log = "Application", machine = "YOTAMLAPTOP";
        private static System.Diagnostics.EventLog _eventLog = new System.Diagnostics.EventLog(log, machine, source);
        

            
        public void WriteEntry(LogEntry entry)
        {
            switch (entry.Severity)
            {
                case Severity.Disaster:
                    _eventLog.WriteEntry(entry.Message, EventLogEntryType.Error);
                    break;
                case Severity.Warning:
                    _eventLog.WriteEntry(entry.Message, EventLogEntryType.Warning);
                    break;
                case Severity.Information:
                    _eventLog.WriteEntry(entry.Message, EventLogEntryType.Information);
                    break;
            }
        }

        public LogEntry[] ReadEntries(DateTime date)
        {
            List<LogEntry> toReturn = new List<LogEntry>();
            foreach (EventLogEntry entry in _eventLog.Entries)
            {
                if(entry.Source.Equals(source))
                    toReturn.Add(new LogEntry(entry));
            }
            return toReturn.ToArray();
        }

        public void ClearLog()
        {
            throw new NotImplementedException();
        }
    }
}