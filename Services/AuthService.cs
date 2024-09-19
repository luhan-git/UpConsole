using Spectre.Console;
using UpSales.Models;
namespace UpSales.Services
{
    public static class AuthService
    {
        private static UserInfo? _currentUser;
        public static UserInfo AuthoriseUser()
        {
            string username = AnsiConsole.Prompt(new TextPrompt<string>("user:")
                                                     .Validate(username => !username.Equals("admin", StringComparison.OrdinalIgnoreCase) 
                                                                   ? ValidationResult.Error("[red]user not found[/]") 
                                                                   : ValidationResult.Success()));
            

            AnsiConsole.Prompt(new TextPrompt<string>("password:")
                                   .Secret()
                                   .Validate(password => !password.Equals("password", StringComparison.OrdinalIgnoreCase) 
                                                 ? ValidationResult.Error("[red]wrong password[/], try again")
                                                 : ValidationResult.Success()));
            

            return _currentUser = new UserInfo(username);
        }
        public static void ClearCredentials()
        {
            _currentUser = null; // Limpia el usuario actual
            AnsiConsole.MarkupLine("[red]Credenciales eliminadas. Inicie sesión nuevamente.[/]");
        }
        public static UserInfo? GetCurrentUser()
        {
            return _currentUser;
        }
    }
}
