using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppAPITemplate
{
	public class App : Application
	{
		public App()
		{
			MainPage = new NavigationPage(new FirstMenu());
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

	public class FirstMenu : MenuList
	{
		/*

			- The first menu that gets it's list items from the first API call
			- When you click a menu item it fires that menu item to the second menu API call 
			- And then takes you to the menu for that item

		*/


		public override void ClickMenuItem(MenuItem itemClicked)
		{
			//Implements menu item click
			//e.g. Navigation.PushAsync(new SecondMenu(e.Item as string));
			Navigation.PushAsync(new SecondMenu(itemClicked));
		}

		public override async Task<List<MenuItem>> RequestTimeAsync()
		{
			//Calls the API

			//Create an Example API
			List<MenuItem> firstMenuList = new List<MenuItem>
			{
				new MenuItem { Name = "1 Thomas", Description = "Is Great"},
				new MenuItem { Name = "1 Cartwright", Description = "Is Also Great"},

			};

			return firstMenuList;

		}


	}

	public class SecondMenu : MenuList
	{
		/*
		 
			- The second menu that gets it's list items from the second API call
			- When you click a menu item it fires that menu item to the second menu API call
			- And then takes you to the screen for that menu item
			
		*/
		public MenuItem currentItem;

		public SecondMenu(MenuItem APIItem) : base()
		{
			this.currentItem = APIItem;

			Title = "API Template 2";
			Content = list;
		}

		public override void ClickMenuItem(MenuItem itemClicked)
		{
			//Implements menu item click
			//e.g. Navigation.PushAsync(new InfoPage(e.Item as string));
			Navigation.PushAsync(new InfoPage(itemClicked));
		}


		public override async Task<List<MenuItem>> RequestTimeAsync()
		{
			//Calls the API for "category"

			//Create an Example API
			List<MenuItem> firstMenuList = new List<MenuItem>
			{
				new MenuItem { Name = "2 Thomas" + this.currentItem.Name, Description = "Is Great"},
				new MenuItem { Name = "2 Cartwright" + this.currentItem.Name, Description = "Is Also Great"},

			};

			return firstMenuList;

		}


	}


	public abstract class MenuList : ContentPage
	{
		/*

		- The menu that gets it's list items from the API call
		- When you click a menu item it takes you to the next screen

		*/
		protected readonly ListView list = new ListView
		{
			/*
				- Starts by just saying "Loading..."
				- When the API call is complete it contains the MenuCells.
			*/
			ItemsSource = new List<MenuItem>
			{
				new MenuItem { Name = "Loading...", Description = "If you click this everything breaks" },
			},
			ItemTemplate = new DataTemplate(typeof(MenuCell)),
			RowHeight = MenuCell.RowHeight,
		};



		public MenuList()
		{
			/*
				- This lists all the menu items and gives a little description
				- Says "Loading" while waiting for the API to return
			*/
			Title = "API Template";
			Content = list;

			list.ItemTapped += (sender, e) =>
			{
				list.SelectedItem = null;
				//Navigation.PushAsync(new SecondMenu(e.Item as MenuItem));
				ClickMenuItem(e.Item as MenuItem);
			};


		}

		protected override async void OnAppearing()
		{
			/*
				- Awaits for API to return values
				- Then changes "list" to contain the MenuCells
			*/

			base.OnAppearing();
			list.ItemsSource = await RequestTimeAsync();
		}

		//What happens when you click on a menu item
		public abstract void ClickMenuItem(MenuItem itemClicked);

		//This sends a request to the API for the menu items
		public abstract Task<List<MenuItem>> RequestTimeAsync();
	}





	public class MenuItem
	{
		/*
			List things that will be displayed on each menu item (probably just two strings)
		*/
		public string Name { get; set; }
		public string Description { get; set; }
	
	}

	public class MenuCell : ViewCell
	{
		/*
			Menu cell = all the code for displaying the info of a MenuItem
		*/
		public const int RowHeight = 55;

		public MenuCell()
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







	public class InfoPage : ContentPage
	{
		/*
			Displays all the information for the API menus	
		*/
		static Label name = new Label
		{
			Text = "Timmy",
			HorizontalOptions = LayoutOptions.Start,
		};


		StackLayout pageInfo = new StackLayout
		{
			Spacing = 0,
			VerticalOptions = LayoutOptions.FillAndExpand,

			Children =
			{
				name,

			},
		};


		public MenuItem currentItem;

		//This holds the Views (it will switch between saying "Loading" and showing the info)
		public InfoPage(MenuItem item)
		{
			currentItem = item;
			Content = pageInfo;


		}


		protected override async void OnAppearing()
		{
			//This will call the API and change the pageInfo once the info has been retrieved
			base.OnAppearing();
			name.Text = await RequestTimeAsync();
		}

		static async Task<string> RequestTimeAsync()
		{
			//This makes the actual API call

			//Create an Example API
			string firstMenuList = "Hello";


			return firstMenuList;
		}

	}
}




















/*
 	public class TimePage : ContentPage
	{
		readonly Label timeLabel = new Label
		{
			Text = "Loading...",
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			VerticalOptions = LayoutOptions.CenterAndExpand,
		};

		public TimePage()
		{
			Content = timeLabel;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			timeLabel.Text = await RequestTimeAsync();
		}

		static async Task<string> RequestTimeAsync()
		{
			using (var client = new HttpClient())
			{
				var jsonString = await client.GetStringAsync("http://date.jsontest.com/");
				var jsonObject = JObject.Parse(jsonString);
				return jsonObject["time"].Value<string>();
			}
		}
	}



	public class DemoStackLayout: StackLayout
	{
	    public DemoStackLayout()
	    {
	        HeightRequest = 70;
	        Spacing = 5;
	        Orientation = StackOrientation.Horizontal;
	        Children.Add(new Icon("A", Color.FromRgb(0.7, 0.8, 1.0)) {
	            WidthRequest = 70,
	        });
	        Children.Add(new StackLayout {
	            Spacing = 2,
	            WidthRequest = 0,
	            HorizontalOptions = LayoutOptions.FillAndExpand,
	            Children = {
	                new Name("Alice"),
	                new Subject("Meeting on Friday"),
	                new Body("Peter, Let's meet on Friday at 10 am"),
	            },
	        });
	        Children.Add(new Time("1:00 PM") {
	            WidthRequest = 50,
	        });
	    }
	}

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
