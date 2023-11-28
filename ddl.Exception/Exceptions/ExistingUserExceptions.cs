using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Exceptions.Exceptions
{
    public class ExistingUserExceptions : Exception
    {
        public ExistingUserExceptions()
        {
        }

        public ExistingUserExceptions(string? message) : base(message)
        {
        }
    }
}
