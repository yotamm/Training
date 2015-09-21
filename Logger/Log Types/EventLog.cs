using System;
using System.Collections.Generic;
using System.Diagnostics;
using Logger.Log_Types.Using;

namespace Logger.Log_Types
{
    public class EventLog : ILog
    {
        private const string Source = "Exercise One";
        private static string log = "Application";
        private static string machine = "YOTAMLAPTOP";
        private static System.Diagnostics.EventLog _eventLog = new System.Diagnostics.EventLog(log, machine, Source);


        public void WriteEntry(LogEntry entry)
        {
            if (!System.Diagnostics.EventLog.SourceExists(Source))
                System.Diagnostics.EventLog.CreateEventSource(Source, log);
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
                if (entry.Source.Equals(Source))
                {
                    Severity severity = Severity.Information;
                    switch (entry.EntryType)
                    {
                        case EventLogEntryType.Information:
                            severity = Severity.Information;
                            break;
                        case EventLogEntryType.Warning:
                            severity = Severity.Warning;
                            break;
                        case EventLogEntryType.Error:
                            severity = Severity.Disaster;
                            break;
                    }
                    toReturn.Add(new LogEntry(severity, entry.Message, entry.TimeWritten));
                }
            }
            return toReturn.ToArray();
        }

        public void ClearLog()
        {
            //TODO
        }
    }
}