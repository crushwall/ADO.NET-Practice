using System;

namespace CubeExceptions
{
    [Serializable]
    public class InvalidNumberOfPointsException : ApplicationException
    {
        public InvalidNumberOfPointsException() { }
        public InvalidNumberOfPointsException(string message) : base(message) { }
        public InvalidNumberOfPointsException(string message, Exception inner) : base(message, inner) { }
        protected InvalidNumberOfPointsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
