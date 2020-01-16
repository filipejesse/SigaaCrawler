using SigaaCrawler.BaseRobo;
using System;
using System.Text.RegularExpressions;

namespace SigaaCrawler
{
    public class ParserSigaa : ParserBase
    {
        public ParserSigaa(string html) 
            : base(html)
        {
        }

        public Result GetData()
        {
            var result = new Result();
            result.Nome = GetValue("//span[@class='nome']/small");
            result.Matricula = GetCourseData("Matrícula");
            result.Ira = GetAcademicPerformanceIndex();
            result.Curso = Regex.Replace(GetCourseData("Curso"), @"[\n\t\r]", string.Empty);
            result.Nivel = GetCourseData("Nível");
            result.StatusMatricula = GetCourseData("Status");
            result.SemestreEntrada = GetCourseData("Entrada");
            result.SemestreAtual = GetValue("//p[@class='periodo-atual']/strong");

            return result;
        }

        private string GetCourseData(string element)
        {
            return GetValue($"//td[contains(text(), '{element}')]/following-sibling::td");
        }

        private double? GetAcademicPerformanceIndex()
        {
            var node = GetValue("//td[..//acronym[text()='IRA:']][4]/div");
            
            if (Double.TryParse(node, out double ira))
                return ira;
            
            return null;
        }

        public string GetValue(string xPath)
        {
            var node = HtmlDocument.DocumentNode.SelectSingleNode(xPath);
            return node?.InnerText.Trim(); ;
        }
    }
}