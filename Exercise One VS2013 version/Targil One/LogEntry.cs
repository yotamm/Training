using System;

namespace Exercise_One
{
    public class LogEntry : IComparable
    {
        private Severity severity;
        private string message;
        private DateTime time;

        public Severity Severity
        {
            get { return severity; }
        }

        public string Message
        {
            get { return message; }
        }

        public DateTime Time
        {
            get { return time; }
        }

        public LogEntry(Severity severity, string message)
        {
            this.severity = severity;
            this.message = message;
            this.time = DateTime.Today;
        }

        public LogEntry(string csvEntry)
        {
            string[] seperated = csvEntry.Split(new char[] {','}, 3);
            Severity severity;
            Severity.TryParse(seperated[0], out severity);
            this.severity = severity;
            DateTime date;
            DateTime.TryParse(seperated[1], out date);
            time = date;
            message = seperated[2];
        }

        public int CompareTo(object obj)
        {
            LogEntry objLogEntry = (LogEntry) obj;
            return this.Time.CompareTo(objLogEntry.Time);
        }
        public override string ToString()
        {

            return severity + ", " + time + ", " + message;
        }

    }
}

