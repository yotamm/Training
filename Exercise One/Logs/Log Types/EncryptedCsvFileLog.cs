using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercise_One
{
    public class EncryptedCsvFileLog : CsvFileLog
    {
        
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
                lines = File.ReadAllLines(_filePath);
                for (int i = 1; i < lines.Length; i++)
                {
                    lines[i] = Encrypt_Decrypt(lines[i]);
                }
            }
            catch (Exception e)
            {
                throw new NoLogDefinedException(_filePath);
            }
            return EntryExtraction(lines, startDate);
        }

        public override void WriteEntry(LogEntry entry)
        {
            try
            {
                string line =
                    Encrypt_Decrypt(GenerateEntryLine(entry));
                File.AppendAllText(_filePath, line);
            }
            catch (Exception e)
            {
                throw new NoLogDefinedException(_filePath);
            }
        }
    }
}