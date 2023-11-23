

using System.Text;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MyCheddarsPal.Helpers;
using MyCheddarsPal.Interfaces;
using MyCheddarsPal.Validators;

namespace MyCheddarsPal.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private readonly ILoginRepository _loginRepository;

    [ObservableProperty] bool isPassword = true;
    [ObservableProperty] string sEmail;
    [ObservableProperty] string password;
    [ObservableProperty] bool isEnabled = true;

    public LoginViewModel(ILoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }

    [RelayCommand]
    public void TogglePasswordVisibility()
    {
        IsPassword = !IsPassword;
    }

    [RelayCommand]
    public async Task GoToMain()
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }

    [RelayCommand]
    public async Task Login()
    {
        IsEnabled = false;
        var loginRequest = new LoginRequest(SEmail, Password);

        var contract = new LoginValidator(loginRequest);

        if (!contract.IsValid)
        {
            var messages = contract.Notifications.Select(x => x.Message);
            var sb = new StringBuilder();

            foreach (var message in messages)
                sb.Append($"{message}\n");

            await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "OK");
            IsEnabled = true;
            return;
        }

        var result = await _loginRepository.LoginAsync(loginRequest);

        IToast toast;

        if (result is null || string.IsNullOrEmpty(result.id.ToString()) || string.IsNullOrEmpty(result.name))
        {
            toast = Toast.Make("Falha ao realizar login, tente novamente!", ToastDuration.Long);
            await toast.Show();

            SEmail = "";
            Password = "";
            IsEnabled = true;
            return;
        }

        toast = Toast.Make("Login efetuado com sucesso!", ToastDuration.Long);
        await toast.Show();

        SessionHelper.SaveToken(result.id.ToString(), DateTime.Now.AddMinutes(30));
        Preferences.Set("userFirstName", result.name);
        IsEnabled = true;

        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}
