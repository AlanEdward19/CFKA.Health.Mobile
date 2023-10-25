using CFKA.Health.Mobile.Pages;
using CFKA.Health.Mobile.ViewModel;

namespace CFKA.Health.Mobile;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Cadastro());
		//count++;

		//if (count == 1)
		//	CounterBtn.Text = $"Clicked {count} time";
		//else
		//	CounterBtn.Text = $"Clicked {count} times";

		//SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

