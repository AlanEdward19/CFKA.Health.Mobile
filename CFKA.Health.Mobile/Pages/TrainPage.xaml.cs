namespace CFKA.Health.Mobile.Pages;

public partial class TrainPage : ContentPage
{
	public TrainPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}