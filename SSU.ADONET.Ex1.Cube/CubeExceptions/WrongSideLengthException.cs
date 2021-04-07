using System;

namespace SSU.ADONET.Ex1.Cube.CubeExceptions
{
    public class WrongSideLengthException : ApplicationException
    {
        public WrongSideLengthException() { }
        public WrongSideLengthException(string message) : base(message) { }
        public WrongSideLengthException(string message, Exception inner) : base(message, inner) { }
    }
}
