namespace MyCheddarsPal.ViewModels;

[QueryProperty(nameof(Train), "Train")]
public partial class TrainDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	TTrainResponse train;
}
