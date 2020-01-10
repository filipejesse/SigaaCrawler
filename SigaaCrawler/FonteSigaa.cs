using SigaaCrawler.BaseRobo;
using SigaaCrawler.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace SigaaCrawler
{
    public class FonteSigaa
    {

        public static string BaseUrl => "https://sig.ifsudestemg.edu.br/sigaa/logar.do?";

        public static string StartNavigation()
        {
            string data = GetRequestParameters();
            var contentType = "application/x-www-form-urlencoded";
            var html = HttpClient.Post(BaseUrl, data, contentType);

            if (html.Contains("Comportamento Inesperado!"))
                throw new ComportamentoInesperadoException("Ocorreu um erro inesperado na consulta!");

            return html;
        }

        private static string GetRequestParameters()
        {
            var login = Uri.EscapeDataString(ConfigurationManager.AppSettings["username"]);
            var senha = Uri.EscapeDataString(ConfigurationManager.AppSettings["password"]);
            var dispatch = Uri.EscapeDataString("logOn");
            return $"dispatch={dispatch}&user.login={login}&user.senha={senha}";
        }
    }
}
