﻿using System.Net;
using System.Text;
using System.Web;
using Sharprompt;

class Program
{

    static void Main(string[] args)
    {
        String Translate(String word)
        {
            var toLanguage = "fa";//Japanese
            //var fromLanguage = selectedLanguage;//English
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {

                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                Console.WriteLine(result);
                return result;
            }
            catch
            {
                return "Error";
            }
        }

        var selectLanguage = Prompt.Select("Select Input Language", new[] { "en", "da" });
        //? To make System Read Japanese
        Console.OutputEncoding = Encoding.Unicode;

        Console.WriteLine("Enter translate text :");
        string text = Console.ReadLine();
        Translate(text);

    }

}


