using CFKA.Health.Mobile.Pages;
using CFKA.Health.Mobile.ViewModel;
using Microsoft.Extensions.Logging;

namespace CFKA.Health.Mobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Inter.ttf", "Inter");
            });

        builder.Services.AddSingleton<InitialPage>();
        builder.Services.AddSingleton<InitialViewModel>();

        #region Pages

        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainViewModel>();

        builder.Services.AddTransient<MainTrainPage>();
        builder.Services.AddTransient<MainTrainViewModel>();

        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<SettingsViewModel>();

        builder.Services.AddTransient<SignUpPage>();
        builder.Services.AddTransient<SignUpViewModel>();

        builder.Services.AddTransient<TrainPage>();
        builder.Services.AddTransient<TrainViewModel>();

        #endregion

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
