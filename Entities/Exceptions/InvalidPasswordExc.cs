using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Exceptions
{
    public class InvalidPasswordExc : Exception
    {
        public InvalidPasswordExc()
        {
        }

        public InvalidPasswordExc(string message) : base(message)
        {
        }

        public InvalidPasswordExc(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
