using AmigoPago.ViewModels;

namespace AmigoPago.Views;

public partial class LoginPage : ContentPage 
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
		BindingContext = loginPageViewModel;
	}
}