using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace BusinessLogic.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class DatabaseException : Exception
    {
        public DatabaseException() { }

        public DatabaseException(string message) : base(message) { }

        public DatabaseException(string message, Exception innerException) : base(message, innerException) { }
    }
}