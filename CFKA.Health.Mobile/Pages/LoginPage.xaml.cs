using CFKA.Health.Mobile.ViewModel;

namespace CFKA.Health.Mobile;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}