namespace People;

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

		var dbPath = FileAccessHelper.GetLocalFilePath("people.db3");
		// in case other dependencies should be resolved, ActivatorUtilities.CreateInstance is used:
		// builder.Services.AddSingleton<PersonRepository>(s => ActivatorUtilities.CreateInstance<PersonRepository>(s, dbPath));

		// simple case
		builder.Services.AddSingleton(s => new PersonRepository(dbPath));

		return builder.Build();
	}
}
