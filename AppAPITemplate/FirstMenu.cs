using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAPITemplate
{
	public class FirstMenu : Menu
	{
		public FirstMenu()
		{
			Title = "API Template";
			Content = list;

			list.ItemsSource = CallAPI(); //Need to add an "await" into this

			list.ItemTapped += (sender, e) =>
			{
				list.SelectedItem = null;
				//Navigation.PushAsync(new SecondMenu(e.Item as MenuItem));
				ClickMenuItem(e.Item as MenuItem);
			};
		}

		public List<MenuItem> CallAPI()
		{
			//Calls the API

			//Create an Example API
			List<MenuItem> menuList = new List<MenuItem>
			{
				new MenuItem { Name = "1 Thomas", Description = "Is Great"},
				new MenuItem { Name = "1 Cartwright", Description = "Is Also Great"},

			};

			return menuList;

			/*
				JSON apiJson = getJSONFromAPI(menuItem);

				List<MenuItem> menuItems = turnJSONIntoMenuItem(apiJson);

			*/
		}

		public void ClickMenuItem(MenuItem itemClicked)
		{
			//Implements menu item click
			//e.g. Navigation.PushAsync(new SecondMenu(e.Item as string));
			Navigation.PushAsync(new SecondMenu(itemClicked));
		}

		/*
			getJsonFromAPI(MenuItem menuItem) {

				string query = constructQuery(menuItem);

				JSON apiJson = query the API
				
			}

			turnJSONIntoMenuItem(JSON apiJson) {

				new MenuItem;
				
				MenuItem.Name = apiJson.name;
				MenuItem.Description = api.Json.description;

			}
		*/

	}
}

