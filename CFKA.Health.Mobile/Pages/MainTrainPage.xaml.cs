namespace CFKA.Health.Mobile.Pages;

public partial class MainTrainPage : ContentPage
{
	public MainTrainPage()
	{
		InitializeComponent();
	}

    private async void btTrainPage_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new TrainPage());
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}