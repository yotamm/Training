using System;

namespace Logger.Infra
{
    public class LogEntry
    {
        public Severity Severity { get; set; } = Severity.Information;
        public string Message { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;

        public override string ToString()
        {
            string result = $"{Severity}, {Time}, {Message}";
            return result;
        }
    }
}