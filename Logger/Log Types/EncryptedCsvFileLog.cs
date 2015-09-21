using System;
using System.IO;
using Logger.Log_Types.Using;

namespace Logger.Log_Types
{
    public class EncryptedCsvFileLog : CsvFileLog
    {
        public EncryptedCsvFileLog(int limit) : base(limit)
        {
        }

        private string Encrypt_Decrypt(string line)
        {
            char[] chars = line.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public override LogEntry[] ReadEntries(DateTime startDate)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(FilePath);
                for (int i = 1; i < lines.Length; i++)
                {
                    lines[i] = Encrypt_Decrypt(lines[i]);
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
            return EntryExtraction(lines, startDate);
        }

        public override void WriteEntry(LogEntry entry)
        {
            try
            {
                if (CurrentEntry != LogLimit)
                {
                    string line =
                        Encrypt_Decrypt(GenerateEntryLine(entry));
                    line += "\n";
                    File.AppendAllText(FilePath, line);
                    CurrentEntry++;
                }
                else
                {
                    throw new LogIsFullException("Log Limit Reached. Please Clear The Log");
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
        }

        
    }
}