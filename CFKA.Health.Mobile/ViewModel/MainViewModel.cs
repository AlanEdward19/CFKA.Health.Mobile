using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace CFKA.Health.Mobile.ViewModel;

public partial class MainViewModel : ObservableObject
{

    [ICommand]
    async Task MoveToLogin()
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }
}