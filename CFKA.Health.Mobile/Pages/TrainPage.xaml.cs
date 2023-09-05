using CFKA.Health.Mobile.ViewModel;

namespace CFKA.Health.Mobile.Pages;

public partial class TrainPage : ContentPage
{
    public TrainPage(TrainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}