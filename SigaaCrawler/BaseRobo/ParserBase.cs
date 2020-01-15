using HtmlAgilityPack;
using System.Web;

namespace SigaaCrawler.BaseRobo
{
    public class ParserBase
    {
        public ParserBase(string html)
        {
            this.Html = HttpUtility.HtmlDecode(html);

            this.HtmlDocument = new HtmlDocument();
            this.HtmlDocument.LoadHtml(this.Html);
        }

        protected string Html { get; set; }

        protected HtmlDocument HtmlDocument { get; set; }
    }
}
