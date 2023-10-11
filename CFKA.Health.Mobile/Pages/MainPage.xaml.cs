using CFKA.Health.Mobile.ViewModel;

namespace CFKA.Health.Mobile.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}