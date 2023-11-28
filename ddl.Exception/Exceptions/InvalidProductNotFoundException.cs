using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Exceptions.Exceptions
{
    public class InvalidProductNotFoundException : Exception
    {
        public InvalidProductNotFoundException()
        {
        }

        public InvalidProductNotFoundException(string? message) : base(message)
        {
        }
    }
}
