namespace MyCheddarsPal.Views;

public partial class TrainPage : ContentPage
{
	TrainViewModel ViewModel;

	public TrainPage(TrainViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = ViewModel = viewModel;
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		await ViewModel.LoadDataAsync();
	}

    private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        ViewModel.FilterTraining();
    }
}
