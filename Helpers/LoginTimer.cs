using Spectre.Console;
using System.Timers;
using UpSales.Models;
using UpSales.Services;
using Timer = System.Timers.Timer;
namespace UpSales.Helpers
{
    public static class LoginTimer
    {
        private static Timer? _loginTimer;
        private static bool _isAutoMode = false;
        private static bool _isLoggedIn = true;
        private static UserInfo? _currentUser;
        public static void SetLoginTimer()
        {
            _loginTimer = new Timer(2000);
            _loginTimer.Elapsed += OnTimedEvent!;
            _loginTimer.AutoReset = true;
            _loginTimer.Enabled = true;
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (!_isAutoMode)
            {
                AnsiConsole.MarkupLine("[yellow]Login requerido después de 20 minutos[/]");
                // Pausar aquí hasta que el login sea exitoso
                while (!_isLoggedIn)
                {
                    var user = AuthService.AuthoriseUser();
                    if (user != null)
                    {
                        _isLoggedIn = true;
                        AnsiConsole.MarkupLine("[green]Login exitoso![/]");
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[red]Login fallido, intente nuevamente[/]");
                    }
                }
            }
        }
        public static void SetAutoMode(bool isAuto)
        {
            _isAutoMode = isAuto;
        }
    }
}
