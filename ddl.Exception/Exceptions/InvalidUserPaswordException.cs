using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Exceptions.Exceptions
{
    public class InvalidUserPaswordException : Exception
    {
        public InvalidUserPaswordException()
        {
        }

        public InvalidUserPaswordException(string? message) : base(message)
        {
        }
    }
}
