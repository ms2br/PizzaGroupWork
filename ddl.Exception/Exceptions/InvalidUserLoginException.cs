using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Exceptions.Exceptions
{
    public class InvalidUserLoginException : Exception
    {
        public InvalidUserLoginException()
        {
        }

        public InvalidUserLoginException(string? message) : base(message)
        {
        }
    }
}
