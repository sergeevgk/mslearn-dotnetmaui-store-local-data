namespace People;

public partial class App : Application
{
    public static PersonRepository PersonRepository { get; private set; }

    public App(PersonRepository repository)
	{
		InitializeComponent();

		MainPage = new AppShell();

		PersonRepository = repository;

	}
}
