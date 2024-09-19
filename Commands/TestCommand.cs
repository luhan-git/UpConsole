using Spectre.Console;
namespace UpSales.Commands
{
    public  class TestCommand:ICommand
    {
        public void Execute()
        {
            var backToMenu = false;
            while (!backToMenu)
            {
                string option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("test options:")
                        .AddChoices(
                            "complete",
                            "calculate",
                            "upload to mongo",
                            "back"));

                switch (option)
                {
                    case "complete":
                        AnsiConsole.MarkupLine("[green]complete:>[/] test sheet");
                        string shouldCompleted = AnsiConsole.Prompt(new TextPrompt<string>("complete in test sheet [[y/n]] (y):")
                                                                           .DefaultValue("y")
                                                                           .AddChoice("y")
                                                                           .AddChoice("n")
                                                                           .AllowEmpty());
                        if (shouldCompleted.Equals("y", StringComparison.OrdinalIgnoreCase))
                        {

                            AnsiConsole.Status()
                                .Spinner(Spinner.Known.Dots)
                                .Start("[yellow]Completing... [/]", ctx =>
                                {
                                    Thread.Sleep(5000);
                                    AnsiConsole.MarkupLine("[green] test sheet completed![/]");
                                });
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[red]test sheet not completed[/]");
                        }
                        break;
                    case "calculate":
                        AnsiConsole.MarkupLine("[green]calculate:>[/] test sheet");
                        string shouldCalculate = AnsiConsole.Prompt(new TextPrompt<string>("calculate in test sheet [[y/n]] (y):")
                                                                        .DefaultValue("y")
                                                                        .AddChoice("y")
                                                                        .AddChoice("n")
                                                                        .AllowEmpty());
                        if (shouldCalculate.Equals("y", StringComparison.OrdinalIgnoreCase))
                        {

                            AnsiConsole.Status()
                                .Spinner(Spinner.Known.Dots)
                                .Start("[yellow] calculating... [/]", ctx =>
                                {
                                    Thread.Sleep(5000);
                                    AnsiConsole.MarkupLine("[green] test sheet calculated![/]");
                                });
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[red]test sheet not calculated[/]");
                        }
                        break;
                    case "upload to mongo":
                        AnsiConsole.MarkupLine("[green]upload to mongo:>[/] test sheet");
                        string shouldUpload = AnsiConsole.Prompt(new TextPrompt<string>("upload to mongo in test sheet [[y/n]] (y):")
                                                                        .DefaultValue("y")
                                                                        .AddChoice("y")
                                                                        .AddChoice("n")
                                                                        .AllowEmpty());
                        if (shouldUpload.Equals("y", StringComparison.OrdinalIgnoreCase))
                        {

                            AnsiConsole.Status()
                                .Spinner(Spinner.Known.Dots)
                                .Start("[yellow] uploading... [/]", ctx =>
                                {
                                    Thread.Sleep(5000);
                                    AnsiConsole.MarkupLine("[green] test sheet upload![/]");
                                });
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[red]test sheet not upload[/]");
                        }
                        break;
                    case "back":
                        backToMenu = true;
                        break;
                }
            }
        }
    }
}
