using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;

namespace Exercise_One
{
    public class EventLog : Logger
    {
        private const string Source = "Exercise_One";
        private static string log = "Application", machine = "YOTAMLAPTOP";
        private static System.Diagnostics.EventLog _eventLog = new System.Diagnostics.EventLog(log, machine, Source);


        public override void WriteEntry(LogEntry entry)
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

        public override LogEntry[] ReadEntries(DateTime date)
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

        public override void ClearLog()
        {
            //TODO
        }
    }
}