using CFKA.Health.Mobile.ViewModel;

namespace CFKA.Health.Mobile.Pages;

public partial class SignUpPage : ContentPage
{
    public SignUpPage(SignUpViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}