using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercise_One
{
    public class EncryptedCsvFileLog : ILog
    {
        private const string FileTitle = "Severity,Time,Message\n";
        public string FilePath { get; }



        public EncryptedCsvFileLog(string fileName)
        {
            FilePath = Directory.GetCurrentDirectory() + "\\" + fileName + ".csv";
            ClearLog();
        }

        public void WriteEntry(LogEntry entry)
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

        public LogEntry[] ReadEntries(DateTime date)
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
                LogEntry current = new LogEntry(Decrypt(lines[i]));
                if (date.CompareTo(current.Time) > 0)
                {
                    break;
                }
                toReturn.Add(current);
            }
            return toReturn.ToArray();
        }

        public void ClearLog()
        {
            File.Delete(FilePath);
            File.AppendAllText(FilePath, Encrypt(FileTitle));
        }

        private string Encrypt(string line)
        {
            return line.Reverse() as string;
        }

        private string Decrypt(string line)
        {
            return line.Reverse() as string;
        }
    }
}