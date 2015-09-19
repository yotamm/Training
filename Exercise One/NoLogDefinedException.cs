using System;
using System.Runtime.Serialization;

namespace Exercise_One
{
    public class NoLogDefinedException : Exception
    {
        public NoLogDefinedException() : base("The log file: is not defined")
        {
        }

        public NoLogDefinedException(string message) : base(message)
        {
        }

        public NoLogDefinedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoLogDefinedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}