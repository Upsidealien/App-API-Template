using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppAPITemplate
{
	public class App : Application
	{
		public App()
		{
			MainPage = new NavigationPage(new APIMenu());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}

	public class APIMenu : ContentPage
	{
		public APIMenu()
		{
			//This lists all the fruits and a little description
			var listView = new ListView
			{
				ItemsSource = new List<APIMenuItem> {
				new APIMenuItem { },
				new APIMenuItem { },
				new APIMenuItem { },
			},
				ItemTemplate = new DataTemplate(typeof(APIMenuCell))
			};

			Content = listView;
		}
	}


	public class APIMenuItem
	{
		/*
			List things that will be displayed on each menu item (probably just two strings)
		*/
	
	}

	public class APIMenuCell : ViewCell
	{
		/*
			Menu cell = all the code around the information in APIMenuItem
		*/

	}


	public class APIMenuPage : ContentPage 
	{ 
		/*
			Displays all the information for the API menus	
		*/
	}
}

/*

	public class FruitListPage : ContentPage
	{
		public FruitListPage()
		{
			//This lists all the fruits and a little description
			var listView = new ListView
			{
				ItemsSource = new List<Fruit> {
				new Fruit { Name = "Apple", Description = "Awesome!" },
				new Fruit { Name = "Banana", Description = "Beautiful!" },
				new Fruit { Name = "Cherry", Description = "Cheap!" },
			},
				ItemTemplate = new DataTemplate(typeof(FruitCell)),
				RowHeight = FruitCell.RowHeight,
			};

			//When you click on any item in the list - it fires up a FruitDetailPage
			listView.ItemTapped += (sender, e) =>
			{
				listView.SelectedItem = null;
				Navigation.PushAsync(new FruitDetailPage(e.Item as Fruit));
			};

			Title = "Fruits";
			Content = listView;
		}
	}

	public class Fruit
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}


	public class FruitCell : ViewCell
	{
		public const int RowHeight = 55;

		public FruitCell()
		{
				var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
				nameLabel.SetBinding(Label.TextProperty, "Name");

				var descriptionLabel = new Label { TextColor = Color.Gray };
				descriptionLabel.SetBinding(Label.TextProperty, "Description");

				View = new StackLayout
				{
					Spacing = 2,
					Padding = 5,
					Children = {
					nameLabel,
					descriptionLabel,
				},	
			};
		}
	}

	public class FruitDetailPage : ContentPage
	{
		public FruitDetailPage(Fruit fruit) 
		{
			Title = fruit.Name;
			Content = new Label
			{
				Text = fruit.Description,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};
		}
	}

*/
