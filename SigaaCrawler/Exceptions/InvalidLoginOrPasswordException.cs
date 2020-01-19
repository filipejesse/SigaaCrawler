using System;
using System.Collections.Generic;
using System.Text;

namespace SigaaCrawler.Exceptions
{
    public class InvalidLoginOrPasswordException : Exception
    {
        public InvalidLoginOrPasswordException(string message)
            : base(message)
        {
        }
    }
}
