using AmigoPago.Models;
using AmigoPago.Services.Interfaces;
using CommunityToolkit.Maui.Alerts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoPago.ViewModels;

public class LoginPageViewModel : INotifyPropertyChanged
{
    private readonly ILoginService loginService;

    public string Usuario { get; set; }
    public string Contraseña { get; set; }
    public Command LoginCommand { get; set; }
    public LoginPageViewModel(ILoginService loginService)
    {
        this.loginService = loginService;
        LoginCommand = new Command(LoginAsync);
        Settings.EmailList = "gustavo@gmail.com,carlos@gmail.com,daniel@gmail.com";
        Settings.PasswordList = "12345, 54321, abcde";
    }
    private async void LoginAsync() 
    {
        var validar = await loginService.LoginAsync(Usuario, Contraseña);
        
        if (validar == false ) 
        {
            await ShowToastAsync("No fue posible iniciar sesion");
            return;
        }
        await ShowToastAsync("Inicio de Sesion Satisfactorio");
    }

    private async Task ShowToastAsync(string message)
    {
        // implement your logic here
        var toast = Toast.Make(message);
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        await toast.Show(cts.Token);
    }
    public event PropertyChangedEventHandler PropertyChanged;
}
