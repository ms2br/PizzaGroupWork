using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Exceptions.Exceptions
{
    public class InvalidUserNotFound : Exception
    {
        public InvalidUserNotFound()
        {
        }

        public InvalidUserNotFound(string? message) : base(message)
        {
        }


    }
}
