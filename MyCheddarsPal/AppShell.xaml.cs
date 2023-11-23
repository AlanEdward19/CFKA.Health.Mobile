namespace MyCheddarsPal;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(TrainDetailPage), typeof(TrainDetailPage));
        Routing.RegisterRoute(nameof(AddTrainPage), typeof(AddTrainPage));
        Routing.RegisterRoute(nameof(AddExercisePage), typeof(AddExercisePage));
        Routing.RegisterRoute(nameof(UpdateTrainPage), typeof(UpdateTrainPage));
        Routing.RegisterRoute(nameof(UpdateExercisePage), typeof(UpdateExercisePage));
    }
}
