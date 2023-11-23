using MyCheddarsPal.Interfaces;
using MyCheddarsPal.Repository;

namespace MyCheddarsPal;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkitMediaElement()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("FontAwesome6FreeBrands.otf", "FontAwesomeBrands");
				fonts.AddFont("FontAwesome6FreeRegular.otf", "FontAwesomeRegular");
				fonts.AddFont("FontAwesome6FreeSolid.otf", "FontAwesomeSolid");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainViewModel>();
        
		builder.Services.AddTransient<TrainDetailPage>();
        builder.Services.AddTransient<TrainDetailViewModel>();

        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<LoginViewModel>();
        
        builder.Services.AddTransient<InitialPage>();
        builder.Services.AddTransient<InitialViewModel>();

        builder.Services.AddTransient<TrainPage>();
        builder.Services.AddTransient<TrainViewModel>();

        builder.Services.AddTransient<AddTrainPage>();
        builder.Services.AddTransient<AddTrainViewModel>();

        builder.Services.AddTransient<AddExercisePage>();
        builder.Services.AddTransient<AddExerciseViewModel>();

        builder.Services.AddTransient<UpdateTrainPage>();
        builder.Services.AddTransient<UpdateTrainViewModel>();

        builder.Services.AddTransient<UpdateExercisePage>();
        builder.Services.AddTransient<UpdateExerciseViewModel>();

        #region Repositories

        builder.Services.AddScoped<ILoginRepository, LoginRepository>();
        builder.Services.AddScoped<ITrainingExerciseRepository, TrainingExerciseRepository>();
        builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();

        #endregion

        return builder.Build();
	}
}
