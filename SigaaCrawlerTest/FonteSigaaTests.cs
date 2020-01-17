using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigaaCrawler;

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
                    Nome = "FILIPE JESSE DE CASTRO ARRUDA",
                    Ira = 7.9695,
                    Curso = "SISTEMAS DE INFORMAÇÃO / JFADEN - Juiz de Fora - BACHARELADO -INT",
                    Matricula = "17006902",
                    Nivel = "Graduação",
                    StatusMatricula = "Ativo",
                    SemestreEntrada = "2017.1",
                    SemestreAtual = "2020.1"
                }, result);
        }
    }
}