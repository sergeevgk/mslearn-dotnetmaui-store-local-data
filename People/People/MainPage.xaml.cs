using People.Models;
using System.Collections.Generic;

namespace People;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	public async void OnNewButtonClicked(object sender, EventArgs args)
	{
		statusMessage.Text = "";

		await App.PersonRepository.AddNewPersonAsync(newPerson.Text);
		statusMessage.Text = App.PersonRepository.StatusMessage;
	}

	public async void OnGetButtonClicked(object sender, EventArgs args)
	{
		statusMessage.Text = "";

		List<Person> people = await App.PersonRepository.GetAllPeopleAsync();
		peopleList.ItemsSource = people;
	}

}

