using System;

namespace Exercise_One
{
    public class LogEntry :IComparable
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

        public LogEntry(string csvEntry)
        {
            string[] seperated = csvEntry.Split(new char[] {','}, 3);
            Severity severity;
            Severity.TryParse(seperated[0], out severity);
            Severity = severity;
            DateTime date;
            DateTime.TryParse(seperated[1], out date);
            Time = date;
            Message = seperated[2];
        }

        public int CompareTo(object obj)
        {
            LogEntry objLogEntry = (LogEntry) obj;
            return this.Time.CompareTo(objLogEntry.Time);
        }

        public override string ToString()
        {
            return Severity + ", " + Time + ", " + Message;
        }
    }
}