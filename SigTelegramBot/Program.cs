using SigaaCrawlerLib;
using System;
using System.Configuration;
using System.Text.RegularExpressions;
using Telegram.Bot;

namespace SigTelegramBot
{
    class Program
    {
        public static readonly TelegramBotClient Bot = new TelegramBotClient(ConfigurationManager.AppSettings["BotToken"]);
        static void Main(string[] args)
        {
            Bot.OnMessage += Bot_OnMessage;
            Bot.OnMessageEdited += Bot_OnMessage;

            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                var match = Regex.Match(e.Message.Text.Trim(), @"(/Dados)\s?:\s?(?<Login>\d+)\s?-\s?(?<Pass>.+)");
                if (match.Success)
                {
                    Result sigaaDados;
                    try
                    {
                        sigaaDados = FonteSigaa.StartNavigation(match.Groups["Login"].Value.Trim(), match.Groups["Pass"].Value.Trim());
                        var stringData = $"Nome: {sigaaDados.Nome}\n\r" +
                                    $"Curso: {sigaaDados.Curso}\n\r" +
                                    $"Ira: {sigaaDados.Ira}\n\r" +
                                    $"Matricula: {sigaaDados.Matricula}\n\r" +
                                    $"Nivel: {sigaaDados.Nivel}\n\r" +
                                    $"Status da Matricula: {sigaaDados.StatusMatricula}\n\r" +
                                    $"Semestre de Entrada: {sigaaDados.SemestreEntrada}\n\r" +
                                    $"Semestre Atual: {sigaaDados.SemestreAtual}";

                        Bot.SendTextMessageAsync(e.Message.Chat.Id, stringData);
                    }
                    catch (Exception ex)
                    {
                        Bot.SendTextMessageAsync(e.Message.Chat.Id, ex.Message);
                    }
                }
                
                else if (e.Message.Text.Trim().Equals("/Bom dia SigBot", StringComparison.OrdinalIgnoreCase))
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, $"Bom dia {e.Message.Chat.Username}");
                }

                else
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, @"Usage: 
                        /Bom dia SigBot 
                        /Dados: Login - Senha
                    ");
                }
            }
        }
    }
}
