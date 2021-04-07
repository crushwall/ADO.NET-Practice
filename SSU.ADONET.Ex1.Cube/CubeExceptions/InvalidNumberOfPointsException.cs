using System;

namespace SSU.ADONET.Ex1.Cube.CubeExceptions
{
    public class InvalidNumberOfPointsException : ApplicationException
    {
        public InvalidNumberOfPointsException() { }
        public InvalidNumberOfPointsException(string message) : base(message) { }
        public InvalidNumberOfPointsException(string message, Exception inner) : base(message, inner) { }
    }
}
