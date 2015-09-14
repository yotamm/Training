using System;

namespace Exercise_One
{
    public class LogEntry
    {
        public Severity Severity { get; }

        public string Message { get; }

        public DateTime Time { get; }

        public LogEntry(Severity severity, string message)
        {
            Severity = severity;
            Message = message;
            Time = DateTime.Today;
        }
    }
}