using System;
using System.Collections.Generic;
using System.Text;

namespace SigaaCrawlerLib
{
    public class Result
    {
        public string Nome { get; set; }

        public string Matricula { get; set; }

        public string Curso { get; set; }

        public string Nivel { get; set; }

        public double? Ira { get; set; }

        public string StatusMatricula { get; set; }

        public string SemestreEntrada { get; set; }

        public string SemestreAtual { get; set; }
    }
}
