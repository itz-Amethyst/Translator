using Spectre.Console;
using System.Net;
using System.Web;

namespace Translator
{
    public static class Translate
    {
        private static int _count = 0;
        [Obsolete("Obsolete")]
        public static String TranslateText(String word)
        {
            var toLanguage = "ja";//Japanese
            //var fromLanguage = selectedLanguage;
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
            var webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            var result = webClient.DownloadString(url);
            try
            {

                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                //? Empty WriteLine
                AnsiConsole.MarkupLine("");

                AnsiConsole.MarkupLine("[cyan]Translated Text : [/]" + result);

                //? Empty WriteLine
                AnsiConsole.MarkupLine("");

                _count++;
                var rule = new Rule($"[red] {_count} [/]");
                rule.Border = BoxBorder.Ascii;

                AnsiConsole.Write(rule);
                //VoicevoxUtility.Speek(result, 39).Wait();
                return result;
            }
            catch
            {
                return "Error";
            }

        }
    }
}
