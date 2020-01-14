using SigaaCrawler.BaseRobo;
using System;

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
            result.Ira = GetAcademicPerformanceIndex();

            return result;
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