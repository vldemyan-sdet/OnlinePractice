using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evershop.Tests.API
{
    [Serializable]
    public class NotSuccessfulRequestException : Exception
    {
        public NotSuccessfulRequestException()
        {
        }

        public NotSuccessfulRequestException(string message)
            : base(message)
        {
        }

        public NotSuccessfulRequestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
