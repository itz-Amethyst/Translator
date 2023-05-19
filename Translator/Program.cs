﻿using System.Media;
using System.Net;
using System.Text;
using System.Web;
using Spectre.Console;

namespace Translator;

class Program
{

    static void Main(string[] args)
    {

        var text = "";

         void BootUp()
        {
            AnsiConsole.Write(
                    new FigletText("Void Translator")
                        .LeftJustified()
                        .Color(Color.Teal)
                );

            var root = new Tree("Root")
                .Guide(TreeGuide.BoldLine);
            root.AddNode("[purple] Translator.sln[/]");

            var Bin = root.AddNode("[yellow]Bin[/]");

            var debug = Bin.AddNode("[green]Debug[/]");

            debug.AddNode("[cyan]Translator.exe [/]");

            var src = root.AddNode("[red] Src [/]");

            src.AddNode("[red] Program.cs[/]");

            src.AddNode("[red] VoiceVoxUtility.cs[/]");

            src.AddNode("[red] BootUp.cs[/]");

            src.AddNode("[red] Translate.cs[/]");



            // Render the tree
            AnsiConsole.Write(root);

            AnsiConsole.Progress()
                .StartAsync(async ctx=>
                {
                    // Define tasks
                    var task1 = ctx.AddTask("[green]Reticulating splines[/]");
                    var task2 = ctx.AddTask("[green]Folding space[/]");

                    while (!ctx.IsFinished)
                    {
                        await Task.Delay(22);
                        task1.Increment(1.5);
                        task2.Increment(0.5);
                    }


                });


        }

        void GetText()
        {
            Console.WriteLine("Enter translate text :");
            text = Console.ReadLine();
        }

        String Translate(String word)
        {
            var toLanguage = "ja";//Japanese
            //var fromLanguage = selectedLanguage;
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
                //VoicevoxUtility.Speek(result, 39).Wait();
                return result;
            }
            catch
            {
                return "Error";
            }

        }

        //var selectLanguage = Prompt.Select("Select Input Language", new[] { "en", "da" });
        //? To make System Read Japanese
        Console.OutputEncoding = Encoding.Unicode;

        BootUp();


        //if (GetText())
        //{
        //    Translate(text);
        //}


    }

}