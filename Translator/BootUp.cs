using Spectre.Console;

namespace Translator
{
    public static class BootUp
    {
        //? Customization part 
        public static void BootUpConsole()
        {
            // Top Bar Section

            AnsiConsole.Write(
                    new FigletText("Void Translator")
                        .Centered()
                        .Color(Color.MediumOrchid1_1)
                );

            var rule = new Rule("[turquoise4] (￣﹃￣) [/]")
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

            // Root Tree

            var root = new Tree("Root")
                .Guide(TreeGuide.BoldLine);
            root.AddNode("[mediumpurple3_1] Translator.sln[/]");

            var Bin = root.AddNode("[gold1]Bin[/]");

            var debug = Bin.AddNode("[lightcyan1]Debug[/]");

            debug.AddNode("[grey62]Translator.exe [/]");

            var src = root.AddNode("[gold1] Src [/]");

            src.AddNode("[darkseagreen4_1] Program.cs[/]");

            src.AddNode("[darkseagreen4_1] VoiceVoxUtility.cs[/]");

            src.AddNode("[darkseagreen4_1] BootUp.cs[/]");

            src.AddNode("[darkseagreen4_1] Translate.cs[/]");

            var treePad = new Padder(root).PadBottom(4).PadLeft(1).PadTop(1);

            // BreakDown Style

            var breakDown = new BreakdownChart()
                .Width(100)
                .ShowPercentage()
                .AddItem("C#", 50, Color.Green)
                .AddItem("Idea", 50, Color.Yellow);

            var breakPad = new Padder(breakDown).PadTop(4);

            // Grid Section

            var grid = new Grid();

            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();

            grid.AddRow(treePad, panelPad, breakPad);

            AnsiConsole.Write(grid);

            var rule2 = new Rule("[slateblue3_1] Enjoy [/]")
            {
                Border = BoxBorder.Heavy
            };

            AnsiConsole.Write(rule2);

        }
    }
}