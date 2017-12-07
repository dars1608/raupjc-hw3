using System;
using System.Runtime.Serialization;

namespace zad2.Core
{
    [Serializable]
    internal class TodoAccessDeniedException : Exception
    {
        public TodoAccessDeniedException()
        {
        }

        public TodoAccessDeniedException(string message) : base(message)
        {
        }

        public TodoAccessDeniedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TodoAccessDeniedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}