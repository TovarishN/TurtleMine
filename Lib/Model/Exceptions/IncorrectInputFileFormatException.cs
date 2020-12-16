using System;
using System.Runtime.Serialization;

namespace TurtleMine
{
    [Serializable]
    internal class IncorrectInputFileFormatException : Exception
    {
        public IncorrectInputFileFormatException()
        {
        }

        public IncorrectInputFileFormatException(string message) : base(message)
        {
        }

        public IncorrectInputFileFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncorrectInputFileFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}