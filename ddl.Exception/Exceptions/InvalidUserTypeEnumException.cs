using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Exceptions.Exceptions
{
    public class InvalidUserTypeEnumException : Exception
    {
        public InvalidUserTypeEnumException()
        {
        }

        public InvalidUserTypeEnumException(string? message) : base(message)
        {
        }
    }
}
