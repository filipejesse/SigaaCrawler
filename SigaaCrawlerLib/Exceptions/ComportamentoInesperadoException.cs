using System;
using System.Collections.Generic;
using System.Text;

namespace SigaaCrawlerLib.Exceptions
{
    public class ComportamentoInesperadoException : Exception
    {
        public ComportamentoInesperadoException(string message)
            : base(message)
        {
        }
    }
}
