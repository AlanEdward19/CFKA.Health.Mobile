namespace MyCheddarsPal.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty] string userFirstName = $"Hello {Preferences.Get("userFirstName", string.Empty)}";
}
