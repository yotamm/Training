using System;
using System.IO;
using Logger.Exceptions;
using Logger.Infra;

namespace Logger.Log_Types
{
    public class EncryptedCsvFileLog : CsvFileLog
    {
        public EncryptedCsvFileLog(int limit) : base(limit)
        {
        }

        protected override string GetCSVString(string line)
        {
            var csvString = base.GetCSVString(line);
            csvString = Encrypt_Decrypt(csvString);
            return csvString;
        }

        protected override string GenerateEntryLine(LogEntry entry)
        {
            var generateEntryLine = base.GenerateEntryLine(entry);
            generateEntryLine = Encrypt_Decrypt(generateEntryLine);
            return generateEntryLine;
        }

        private string Encrypt_Decrypt(string line)
        {
            char[] chars = line.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}