namespace MyCheddarsPal.ViewModels;

public partial class InitialViewModel : BaseViewModel
{

    [RelayCommand]
    public async Task GoToLogin()
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }

    [RelayCommand]
    public async Task ShowGroupInfo()
    {
        await Shell.Current.DisplayAlert("Desenvolvedores", "Alan Oliveira - 210184\nConrado Setti - 210623\nGabriel Portillo - 210236\nLuis Felipe - 210206\nLuiz Henrique - 211325", "OK");
    }
}
