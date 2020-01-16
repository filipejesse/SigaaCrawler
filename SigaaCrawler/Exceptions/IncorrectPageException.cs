using System;
using System.Collections.Generic;
using System.Text;

namespace SigaaCrawler.Exceptions
{
    class IncorrectPageException : Exception
    {
        public IncorrectPageException(string message) 
            : base(message)
        {
        }
    }
}
