using System;
using System.Collections.Generic;
using System.Text;

namespace SigaaCrawlerLib.Exceptions
{
    public class IncorrectPageException : Exception
    {
        public IncorrectPageException(string message)
            : base(message)
        {
        }
    }
}
