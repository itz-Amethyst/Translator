using System;
using System.Text;
using Spectre.Console;
using static System.Console;

namespace Translator;

class Program
{

    [Obsolete("Obsolete")]
    static void Main(string[] args)
    {
        SetWindowSize(180, 40);

        var text = "";

        void GetText()
        {
            //? Empty WriteLine
            AnsiConsole.MarkupLine("");

            text = AnsiConsole.Ask<string>("Enter [green]Text[/] to [Purple]Translate [/]:");

            Translate.TranslateText(text);
        }


        //? To make System Read Japanese
        OutputEncoding = Encoding.Unicode;
        InputEncoding = Encoding.Unicode;

        BootUp.BootUpConsole();

        while (true)
        {
            GetText();

        }

    }

}