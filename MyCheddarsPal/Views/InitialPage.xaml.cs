namespace MyCheddarsPal.Views;

public partial class InitialPage : ContentPage
{
	public InitialPage(InitialViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
