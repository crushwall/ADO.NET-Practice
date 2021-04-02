using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeExceptions
{
    public class WrongSideLengthException : ApplicationException
    {
        public WrongSideLengthException() { }
        public WrongSideLengthException(string message) : base(message) { }
        public WrongSideLengthException(string message, Exception inner) : base(message, inner) { }
    }
}
