using System;
namespace BusinessLogic.Exceptions
{
    public class InvalidMessageFormat : Exception
    {
        public InvalidMessageFormat() { }

        public InvalidMessageFormat(string message) : base(message) { }

        public InvalidMessageFormat(string message, Exception innerException) : base(message, innerException) { }
    }
}