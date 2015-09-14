using System;

namespace Exercise_One
{
    public class NoLogDefinedException : Exception
    {
        public NoLogDefinedException(string fileName) : base($"The log file: {fileName} is not defined")
        {
        }
    }
}