using CFKA.Health.Mobile.ViewModel;

namespace CFKA.Health.Mobile.Pages;

public partial class MainTrainPage : ContentPage
{
    public MainTrainPage(MainTrainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}