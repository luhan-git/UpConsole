using Spectre.Console;
using UpSales.Commands;
using UpSales.Helpers;
using UpSales.Services;
var commands = new Dictionary<string, ICommand>
{
    { "test", new TestCommand() },
    { "run", new RunCommand() },
    { "auto", new AutoCommand() },
    { "back", new BackCommand() }
};
var user=AuthService.AuthoriseUser();
LoginTimer.SetLoginTimer();
while (true)
{
    string mainOption = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("main menu:")
            .AddChoices(commands.Keys.ToArray()));
    if (commands.TryGetValue(mainOption, out var value))
    {
        value.Execute();
    }
    if (mainOption == "auto")
    {
        // Notificar que el modo automático está activo
        LoginTimer.SetAutoMode(true);

        // Ejecutar el comando 'auto' en segundo plano
        await Task.Run(() =>
        {
            commands[mainOption].Execute();
            // Cuando termine, volver a poner isAutoMode en false
            LoginTimer.SetAutoMode(false);
        });
    }
    else
    {
        if (commands.TryGetValue(mainOption, out var values))
        {
            values.Execute();
        }
    }
}