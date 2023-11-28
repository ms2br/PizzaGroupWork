using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Exceptions.Exceptions
{
    public class InvalidUserPhoneNumberException : Exception
    {
        public InvalidUserPhoneNumberException()
        {
        }

        public InvalidUserPhoneNumberException(string? message) : base(message)
        {
        }
    }
}
