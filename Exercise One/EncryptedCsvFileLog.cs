using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercise_One
{
    public class EncryptedCsvFileLog : Logger
    {
        
        public EncryptedCsvFileLog(string fileName)
        {
            FilePath = Directory.GetCurrentDirectory() + "\\" + fileName + ".csv";
            
        }

        private string Encrypt(string line)
        {
            return line.Reverse() as string;
        }

        private string Decrypt(string line)
        {
            return line.Reverse() as string;
        }

        public override LogEntry[] ReadEntries(DateTime startDate)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(FilePath);
            }
            catch (Exception e)
            {
                throw new NoLogDefinedException(FilePath);
            }
            List<LogEntry> toReturn = new List<LogEntry>();
            for (int i = lines.Length - 1; i >= 1; i--)
            {
                lines[i] = Decrypt(lines[i]); //TODO there is code duplication here with csvFileLog, fix it with abstracts
                string[] seperated = lines[i].Split(new[] { ',' }, 3);
                Severity severity;
                Enum.TryParse(seperated[0], out severity);
                DateTime time;
                DateTime.TryParse(seperated[1], out time);
                LogEntry current = new LogEntry(severity, seperated[2], time);
                if (startDate.CompareTo(current.Time) > 0)
                {
                    break;
                }
                toReturn.Add(current);
            }
            return toReturn.ToArray();
        }

        public override void WriteEntry(LogEntry entry)
        {
            try
            {
                File.AppendAllText(FilePath, Encrypt($"{entry.Severity.ToString()},{entry.Time.ToString()},\"{entry.Message}\"\n"));
            }
            catch (Exception e)
            {
                throw new NoLogDefinedException(FilePath);
            }
        }
    }
}