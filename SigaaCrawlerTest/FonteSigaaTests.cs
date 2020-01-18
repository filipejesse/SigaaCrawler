using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigaaCrawler;
using System.Configuration;

namespace SigaaCrawlerTest
{
    [TestClass()]
    public class FonteSigaaTests
    {
        [TestMethod()]
        public void StartNavigationTest()
        {
            var result = FonteSigaa.StartNavigation();
            Assert.AreEqual(
                new Result
                {
                    Curso = "SISTEMAS DE INFORMAÇÃO/JFADEN - Juiz de Fora - BACHARELADO -INT",
                    Ira = 7.9695,
                    Matricula = "17006902",
                    Nivel = "GRADUAÇÃO",
                    Nome = "FILIPE JESSE DE CASTRO ARRUDA",
                    StatusMatricula = "ATIVO",
                    SemestreEntrada = "2017.1",
                    SemestreAtual = "2020.1"
                }, result);
        }
    }
}