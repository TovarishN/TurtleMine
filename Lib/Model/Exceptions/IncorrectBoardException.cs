using System;
using System.Runtime.Serialization;

namespace TurtleMine
{
    [Serializable]
    internal class IncorrectBoardException : Exception
    {
        public IncorrectBoardException()
        {
        }

        public IncorrectBoardException(string message) : base(message)
        {
        }

        public IncorrectBoardException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncorrectBoardException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}