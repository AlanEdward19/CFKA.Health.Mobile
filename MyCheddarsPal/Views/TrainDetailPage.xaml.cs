using CommunityToolkit.Maui.Views;

namespace MyCheddarsPal.Views;

public partial class TrainDetailPage : ContentPage
{
	public TrainDetailPage(TrainDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    //void Page_Unloaded(object sender, EventArgs e)
    //{
    //    // Stop and cleanup MediaElement when we navigate away
    //    MediaElement.Handler?.DisconnectHandler();
    //}
}
