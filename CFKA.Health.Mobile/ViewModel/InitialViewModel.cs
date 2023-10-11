using CFKA.Health.Mobile.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace CFKA.Health.Mobile.ViewModel;

public partial class InitialViewModel : ObservableObject
{

    [ICommand]
    async Task MoveToLogin()
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }

    [ICommand]
    async Task MoveToSignUpPage()
    {
        await Shell.Current.GoToAsync(nameof(SignUpPage));
    }
}