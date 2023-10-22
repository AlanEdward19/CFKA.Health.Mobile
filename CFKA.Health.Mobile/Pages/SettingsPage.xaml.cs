using CFKA.Health.Mobile.ViewModel;

namespace CFKA.Health.Mobile.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(SettingsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}