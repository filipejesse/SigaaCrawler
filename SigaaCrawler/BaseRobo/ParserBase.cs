using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SigaaCrawler.BaseRobo
{
    public class ParserBase
    {
        public ParserBase(string html)
        {
            this.Html = html;

            this.HtmlDocument = new HtmlDocument();
            this.HtmlDocument.LoadHtml(html);
        }

        protected string Html { get; set; }

        protected HtmlDocument HtmlDocument { get; set; }
    }
}
