using CFKA.Health.Mobile.ViewModel;

namespace CFKA.Health.Mobile;

public partial class InitialPage : ContentPage
{

    public InitialPage(InitialViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}

