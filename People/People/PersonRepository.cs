using SQLite;
using People.Models;
namespace People;

public class PersonRepository
{
	readonly string _dbPath;

	public string StatusMessage { get; set; }

	private SQLiteAsyncConnection _connection;

	private async Task Init()
	{
		if (_connection != null)
			return;

		_connection = new SQLiteAsyncConnection(_dbPath);
		await _connection.CreateTableAsync<Person>();
	}

	public PersonRepository(string dbPath)
	{
		_dbPath = dbPath;
	}

	public async Task AddNewPersonAsync(string name)
	{
		try
		{
			await Init();
			// basic validation to ensure a name was entered
			if (string.IsNullOrEmpty(name))
				throw new Exception("Valid name required");

			var person = new Person { Name = name };
			var result = await _connection.InsertAsync(person);

			StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
		}
		catch (Exception ex)
		{
			StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
		}

	}

	public async Task<List<Person>> GetAllPeopleAsync()
	{
		try
		{
			await Init();
			var result = await _connection.Table<Person>().ToListAsync();

			return result;
		}
		catch (Exception ex)
		{
			StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
		}

		return new List<Person>();
	}
}
