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
            result.Matricula = GetCourseData("Matrícula");
            result.Ira = GetAcademicPerformanceIndex();
            result.Curso = Regex.Replace(GetCourseData("Curso"), @"[\n\t\r]", string.Empty);
            result.Nivel = GetCourseData("Nível");
            result.StatusMatricula = GetCourseData("Status");
            result.SemestreEntrada = GetCourseData("Entrada");

            return result;
        }

        private string GetCourseData(string element)
        {
            var node = HtmlDocument.DocumentNode.SelectSingleNode($"//td[contains(text(), '{element}')]/following-sibling::td");
            return node?.InnerText.Trim();
        }

        private double? GetAcademicPerformanceIndex()
        {
            var node = HtmlDocument.DocumentNode.SelectSingleNode("//td[..//acronym[text()='IRA:']][4]/div");

            if (Double.TryParse(node?.InnerText, out double ira))
                return ira;
            
            return null;
        }
    }
}