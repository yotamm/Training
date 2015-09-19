using System;

namespace Logger.Log_Types.Using
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
            Time = DateTime.Now;
        }

        public LogEntry(Severity severity, string message, DateTime time)
        {
            Severity = severity;
            Message = message;
            Time = time;
        }

        public override string ToString()
        {
            string result = $"{Severity}, {Time}, {Message}";
            return result;
        }
    }
}