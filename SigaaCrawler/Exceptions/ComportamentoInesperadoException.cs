using System;
using System.Collections.Generic;
using System.Text;

namespace SigaaCrawler.Exceptions
{
    public class ComportamentoInesperadoException : Exception
    {
        public ComportamentoInesperadoException(string message) 
            : base(message)
        {
        }
    }
}
