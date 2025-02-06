using Microsoft.Extensions.Logging;

namespace AlarmTest2;

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
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

#if IOS
		builder.Services.AddSingleton<INotificationManagerService, Platforms.iOS.NotificationManagerService>();
#endif
		builder.Services.AddSingleton<MainPage>();
		return builder.Build();
	}
}
