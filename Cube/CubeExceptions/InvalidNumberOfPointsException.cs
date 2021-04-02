using System;

namespace CubeExceptions
{
    public class InvalidNumberOfPointsException : ApplicationException
    {
        public InvalidNumberOfPointsException() { }
        public InvalidNumberOfPointsException(string message) : base(message) { }
        public InvalidNumberOfPointsException(string message, Exception inner) : base(message, inner) { }
    }
}
