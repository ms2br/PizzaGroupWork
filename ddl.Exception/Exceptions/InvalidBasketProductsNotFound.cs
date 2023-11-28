using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Exceptions.Exceptions
{
    public class InvalidBasketProductsNotFound : Exception
    {
        public InvalidBasketProductsNotFound()
        {
        }

        public InvalidBasketProductsNotFound(string? message) : base(message)
        {
        }
    }
}
