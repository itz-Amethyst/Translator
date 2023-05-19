using Spectre.Console;

namespace Translator
{
    public static class BootUp
    {
       public static void BootUpConsole()
        {
            AnsiConsole.Write(
                    new FigletText("Void Translator")
                        .Centered()
                        .Color(Color.Teal)
                );

            var rule = new Rule("[red] (￣﹃￣) [/]")
            {
                Border = BoxBorder.Heavy
            };

            var rulePad = new Padder(rule).PadBottom(3);

            AnsiConsole.Write(rulePad);

            var panel = new Panel("Fix VoiceVox")
            {
                Header = new PanelHeader("Todo")
            };

            panel.HeaderAlignment(Justify.Center);

            panel.Padding = new Padding(3, 3, 3, 3);

            panel.Border = BoxBorder.Ascii;

            var panelPad = new Padder(panel).PadRight(6);

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


            var treePad = new Padder(root).PadBottom(4).PadLeft(1).PadTop(1);

            var breakDown = new BreakdownChart()
                .Width(100)
                .ShowPercentage()
                .AddItem("C#", 50, Color.Green)
                .AddItem("Idea", 50, Color.Yellow);

            var breakPad = new Padder(breakDown).PadTop(4);

            var grid = new Grid();

            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();

            grid.AddRow(treePad, panelPad, breakPad);

            AnsiConsole.Write(grid);

            var rule2 = new Rule("[blue] Enjoy [/]")
            {
                Border = BoxBorder.Heavy
            };

            AnsiConsole.Write(rule2);

        }
    }
}
