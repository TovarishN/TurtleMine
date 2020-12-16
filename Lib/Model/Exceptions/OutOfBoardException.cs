using System;
using System.Runtime.Serialization;

namespace TurtleMine
{
    [Serializable]
    public class OutOfBoardException : Exception
    {
        public OutOfBoardException()
        {
        }

        public OutOfBoardException(string message) : base(message)
        {
        }

        public OutOfBoardException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OutOfBoardException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}