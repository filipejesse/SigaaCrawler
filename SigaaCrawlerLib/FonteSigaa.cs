using SigaaCrawlerLib.BaseRobo;
using SigaaCrawlerLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SigaaCrawlerLib
{
    public class FonteSigaa
    {
        public static string BaseUrl => "https://sig.ifsudestemg.edu.br/sigaa/logar.do?";

        public static Result StartNavigation(string login, string pass)
        {
            if (string.IsNullOrWhiteSpace(login)) 
                throw new ArgumentException("Login inválido");

            if (string.IsNullOrWhiteSpace(pass)) 
                throw new ArgumentException("Senha inválida");

            var data = GetRequestParameters(login, pass);
            var html = GetResponse(data);

            if (html.Contains("Comportamento Inesperado!"))
                throw new ComportamentoInesperadoException("Ocorreu um erro inesperado na consulta!");

            if (html.Contains("Usuário e/ou senha inválidos"))
                throw new InvalidLoginOrPasswordException("Usuário ou senha incorretos.");

            if (!html.Contains("Dados Institucionais"))
                throw new IncorrectPageException("Erro ao navegar para site. Página encontrada não é válida");


            var parser = new ParserSigaa(html);

            var result = parser.GetData();

            return result;
        }

        private static string GetResponse(string data)
        {
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
            while (retries <= maxRetries)
            {
                html = HttpClient.Post(BaseUrl, data, contentType, cookie, userAgent, out var status);
                if (status == HttpStatusCode.OK)
                    break;

                retries++;
            }
            return html;
        }

        private static string GetRequestParameters(string user, string password)
        {
            var login = Uri.EscapeDataString(user);
            var senha = Uri.EscapeDataString(password);
            var dispatch = Uri.EscapeDataString("logOn");
            return $"dispatch={dispatch}&user.login={login}&user.senha={senha}&width=1024&height=768";
        }
    }
}
