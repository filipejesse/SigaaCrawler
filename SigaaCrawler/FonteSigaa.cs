using SigaaCrawler.BaseRobo;
using SigaaCrawler.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SigaaCrawler
{
    public class FonteSigaa
    {
        public static string BaseUrl => "https://sig.ifsudestemg.edu.br/sigaa/logar.do?";

        public static Result StartNavigation()
        {
            var html = GetResponse();

            if (html.Contains("Comportamento Inesperado!"))
                throw new ComportamentoInesperadoException("Ocorreu um erro inesperado na consulta!");

            if (!html.Contains("Dados Institucionais"))
                throw new IncorrectPageException("Página encontrada não é válida");
           
            var parser = new ParserSigaa(html);

            var result = parser.GetData();

            return result;
        }

        private static string GetResponse()
        {
            string data = GetRequestParameters();
            var contentType = "application/x-www-form-urlencoded";
            var userAgent = "PostmanRuntime/7.21.0";
            var cookie = new Cookie()
            {
                Name = "JSESSIONID",
                Value = "1216A54C01C149AE600E3CD3642B9036.node8",
                Domain = "sig.ifsudestemg.edu.br",
                Secure = true,
                HttpOnly = true,
                Path = "/"
            };

            string html = string.Empty;
            var retries = 0;
            var maxRetries = 3;
            while(retries <= maxRetries)
            {
                html = HttpClient.Post(BaseUrl, data, contentType, cookie, userAgent, out var status);
                if (status == HttpStatusCode.OK)
                    break;
               
                retries++;
            }
            return html;
        }

        private static string GetRequestParameters()
        {
            var login = Uri.EscapeDataString(ConfigurationManager.AppSettings["username"]);
            var senha = Uri.EscapeDataString(ConfigurationManager.AppSettings["password"]);
            var dispatch = Uri.EscapeDataString("logOn");
            return $"dispatch={dispatch}&user.login={login}&user.senha={senha}&width=1024&height=768";
        }
    }
}
